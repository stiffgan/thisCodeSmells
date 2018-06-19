using RefactoringDog.Application.Contracts.DTOs;
using RefactoringDog.Application.Contracts.Enums;

namespace RefactoringDog.Application.Contracts
{
    public interface IDogService
    {
        string AdoptDog(DogBreedDto race, string userName);
        string DepositDog(DogDto dog, string userName);
    }
}
