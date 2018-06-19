namespace RefactoringDog.Application.Contracts.Exceptions
{
    public class DogBreedNotExistException : System.Exception
    {
        public DogBreedNotExistException()
        {

        }
        public DogBreedNotExistException(string message) : base(message)
        {

        }
        public DogBreedNotExistException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
