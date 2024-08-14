namespace BestwaySolutionsTestAPI.Exceptions
{
    public class FruitNotFoundException : Exception
    {
        public FruitNotFoundException(string name)
            : base($"Fruit with the name '{name}' could not be found.")
        {
        }
    }
}
