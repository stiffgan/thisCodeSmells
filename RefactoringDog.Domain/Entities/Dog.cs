using System;
using RefactoringDog.Domain.Enums;

namespace RefactoringDog.Domain.Entities
{
    public class Dog
    {
        public Guid DogHouseId { get; set; }
        public bool IsInDogHouse { get; set; }
        public DateTime DepositAt { get; set; }
        public DogBreed Race { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
