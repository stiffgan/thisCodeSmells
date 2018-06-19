using RefactoringDog.Application.Contracts.DTOs;
using RefactoringDog.Application.Contracts.Enums;
using RefactoringDogFront.Enum;
using RefactoringDogFront.Refactor;
using System;

namespace RefactoringDogFront.Mapper
{
    internal static class DogMapper
    {
        public static DogBreedDto MapDogBreedToDto(DogBreedEnum race)
        {
            switch (race)
            {
                case DogBreedEnum.Boxer:
                    return DogBreedDto.Boxer;
                case DogBreedEnum.Bulldog:
                    return DogBreedDto.Bulldog;
                case DogBreedEnum.Chihuahua:
                    return DogBreedDto.Chihuahua;
                case DogBreedEnum.GermanShepherd:
                    return DogBreedDto.GermanShepherd;
                case DogBreedEnum.Rotweiler:
                    return DogBreedDto.Rotweiler;
                default:
                    throw new Exception("Error");
            }
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
