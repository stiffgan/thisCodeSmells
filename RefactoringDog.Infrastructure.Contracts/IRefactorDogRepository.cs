using RefactoringDog.Domain.Entities;
using System.Collections.Generic;

namespace RefactoringDog.Infrastructure.Contracts
{
    public interface IRefactorDogRepository
    {
        Dog AdoptDog(DogBreed race);
        void DepositDog(Dog dog);
        IEnumerable<Dog> GetDogs();
    }
}
