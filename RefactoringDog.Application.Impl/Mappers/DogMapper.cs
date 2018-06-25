using RefactoringDog.Application.Contracts.DTOs;
using RefactoringDog.Domain.Entities;

namespace RefactoringDog.Application.Impl.Mappers
{
    internal static class DogMapper
    {
        public static DogBreed MapDogBreedToEntity(DogBreedDto raceDto)
        {
            return new DogBreed
            {
                Name = raceDto.Name
            };

        }
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
