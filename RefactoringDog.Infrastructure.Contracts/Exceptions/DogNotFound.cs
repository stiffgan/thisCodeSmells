namespace RefactoringDog.Infrastructure.Contracts.Exceptions
{
    public class DogNotFoundException : System.Exception
    {
        public DogNotFoundException()
        {

        }
        public DogNotFoundException(string message) : base(message)
        {

        }
        public DogNotFoundException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
