﻿using RefactoringDog.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using RefactoringDog.Domain.Entities;

namespace RefactoringDog.Infrastructure.Mocks
{
    public class RefactorDogMockRepository : IRefactorDogRepository
    {
        private static List<Dog> _dogs = new List<Dog>()
        {
            new Dog
            {
                DogHouseId = Guid.NewGuid(),
                Name = "MAKI",
                Age = 3,
                DepositAt = DateTime.UtcNow.AddMonths(-(new Random().Next(0, 24))),
                IsInDogHouse = true,
                Race = new DogBreed { Name = "Rotweiler" }
            },
            new Dog
            {
                DogHouseId = Guid.NewGuid(),
                Name = "PIMI",
                Age = 9,
                DepositAt = DateTime.UtcNow.AddMonths(-(new Random().Next(0, 24))),
                IsInDogHouse = true,
                Race = new DogBreed { Name = "Chihuahua" }
            },
            new Dog
            {
                DogHouseId= Guid.NewGuid(),
                Name = "TIGER",
                Age = 5,
                DepositAt = DateTime.UtcNow.AddMonths(-(new Random().Next(0, 24))),
                IsInDogHouse = true,
                Race = new DogBreed { Name = "GermanShepherd" }
            }
        };
        public Dog AdoptDog(DogBreed race)
        {
            var dog = _dogs.Where(x => x.Race.Name == race.Name && x.IsInDogHouse).FirstOrDefault();
            return dog;
        }

        public void DepositDog(Dog dog)
        {
            _dogs.Add(dog);
        }

        public IEnumerable<Dog> GetDogs()
        {
            return _dogs;
        }
    }
}
