using RefactoringDog.Application.Contracts.DTOs;
using RefactoringDog.Application.Contracts.Enums;
using RefactoringDog.Application.Contracts.Exceptions;
using RefactoringDog.Domain.Entities;
using RefactoringDog.Domain.Enums;
using System;


namespace RefactoringDog.Application.Impl.Mappers
{
    internal static class DogMapper
    {
        public static DogBreed MapDogBreedToEntity(DogBreedDto raceDto)
        {
            switch (raceDto)
            {
                case DogBreedDto.Boxer:
                    return DogBreed.Boxer;
                case DogBreedDto.Bulldog:
                    return DogBreed.Bulldog;
                case DogBreedDto.Chihuahua:
                    return DogBreed.Chihuahua;
                case DogBreedDto.GermanShepherd:
                    return DogBreed.GermanShepherd;
                case DogBreedDto.Rotweiler:
                    return DogBreed.Rotweiler;
                default:
                    throw new DogBreedNotExistException("Dog breed not exist");
            }

        }
        public static DogBreedDto MapDogBreedToDto(DogBreed race)
        {
            switch (race)
            {
                case DogBreed.Boxer:
                    return DogBreedDto.Boxer;
                case DogBreed.Bulldog:
                    return DogBreedDto.Bulldog;
                case DogBreed.Chihuahua:
                    return DogBreedDto.Chihuahua;
                case DogBreed.GermanShepherd:
                    return DogBreedDto.GermanShepherd;
                case DogBreed.Rotweiler:
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

        public static Dog MapDogToEntity(DogDto dogDto)
        {
            return new Dog
            {
                Age = dogDto.Age,
                DepositAt = dogDto.DepositAt,
                DogHouseId = dogDto.DogHouseId,
                Name = dogDto.Name,
                IsInDogHouse = dogDto.IsInDogHouse,
                Race = MapDogBreedToEntity(dogDto.Race)
            };
        }
    }
}
