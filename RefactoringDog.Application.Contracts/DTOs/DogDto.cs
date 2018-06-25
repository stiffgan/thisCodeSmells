
using System;

namespace RefactoringDog.Application.Contracts.DTOs
{
    public class DogDto
    {
        public Guid DogHouseId { get; set; }
        public bool IsInDogHouse { get; set; }
        public DateTime DepositAt { get; set; }
        public DogBreedDto Race { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description => $"{Name}. {Race.Name}. {Age} years.";
    }
}
