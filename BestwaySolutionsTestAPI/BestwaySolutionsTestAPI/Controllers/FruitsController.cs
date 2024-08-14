using BestwaySolutionsTestAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace BestwaySolutionsTestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FruitsController : ControllerBase
    {
        private readonly FruitService _fruitService;


        public FruitsController(FruitService fruitService)
        {
            _fruitService = fruitService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetFruit(string name)
        {
            var fruit = await _fruitService.GetFruitByName(name);
           
            return Ok(fruit);
        }

        [HttpPost("{name}/metadata")]
        public IActionResult AddMetadata(string name, [FromBody] KeyValuePair<string, string> metadata)
        {
            var fruit = _fruitService.GetFruitByName(name).Result;
          
            _fruitService.AddMetadata(name ,fruit, metadata.Key, metadata.Value);
            return Ok(fruit);
        }

        [HttpDelete("{name}/metadata/{key}")]
        public IActionResult RemoveMetadata(string name, string key)
        {
            var fruit = _fruitService.GetFruitByName(name).Result;
           
            _fruitService.RemoveMetadata(name,fruit, key);
            return Ok(fruit);
        }

        [HttpPut("{name}/metadata/{key}")]
        public IActionResult UpdateMetadata(string name, string key, [FromBody] string newValue)
        {
            var fruit = _fruitService.GetFruitByName(name).Result;
          
            _fruitService.UpdateMetadata(name ,fruit, key, newValue);
            return Ok(fruit);
        }
    }
}
