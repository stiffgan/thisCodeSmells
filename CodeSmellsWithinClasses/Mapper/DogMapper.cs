using RefactoringDog.Application.Contracts.DTOs;
using RefactoringDogFront.Refactor;
using System;

namespace RefactoringDogFront.Mapper
{
    internal static class DogMapper
    {
        public static DogBreedDto MapDogBreedToDto(DogBreed race)
        {
            return new DogBreedDto
            {
                Name = race.Name
            };
        }
        public static DogDto MapDogToDto(Dog dog)
        {
            return new DogDto
            {
                Age = dog.Age,
                DepositAt = dog.DepositAt,
                DogHouseId = dog.DogHouseId,
                Name = dog.Name,
                IsInDogHouse = dog.IsInDogHouse,
                Race = MapDogBreedToDto(dog.Race)
            };
        }
    }
}
