namespace BestwaySolutionsTestAPI.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException()
            : base("Internal server error")
        {
        }
    }
}
