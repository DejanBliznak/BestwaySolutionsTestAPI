using BestwaySolutionsTestAPI.Exceptions;
using BestwaySolutionsTestAPI.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Xml.Linq;

namespace BestwaySolutionsTestAPI.Service
{

    public class FruitService
    {

        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;

        public FruitService(HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        public async Task<Fruit> GetFruitByName(string name)
        {
            if (_cache.TryGetValue(name, out Fruit fruit))
            {
                return fruit;
            }

            var response = await _httpClient.GetAsync($"https://www.fruityvice.com/api/fruit/{name}");
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new FruitNotFoundException(name);
                }
                else
                {
                    throw new InternalServerErrorException();
                }

            }

            var content = await response.Content.ReadAsStringAsync();
            fruit = JsonConvert.DeserializeObject<Fruit>(content);

            _cache.Set(name, fruit, TimeSpan.FromMinutes(10));


            return fruit;
        }

        public void AddMetadata(string name, Fruit fruit, string key, string value)
        {
            fruit.metadata[key] = value;
            _cache.Set(name, fruit, TimeSpan.FromMinutes(10));
        }

        public void RemoveMetadata(string name, Fruit fruit, string key)
        {
            if (fruit.metadata.ContainsKey(key))
            {
                fruit.metadata.Remove(key);
            }
            _cache.Set(name, fruit, TimeSpan.FromMinutes(10));
        }

        public void UpdateMetadata(string name, Fruit fruit, string key, string newValue)
        {
            if (fruit.metadata.ContainsKey(key))
            {
                fruit.metadata[key] = newValue;
            }
            _cache.Set(name, fruit, TimeSpan.FromMinutes(10));
        }
    }
}
