using RefactoringDogFront.Enum;
using System;

namespace RefactoringDogFront.Refactor
{
    public class Dog
    {
        public Guid DogHouseId { get; set; }
        public bool IsInDogHouse { get; set; }
        public DateTime DepositAt { get; set; }
        public DogBreedEnum Race { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Dog(Guid dogHouseId, bool isInDogHouse, DateTime depositAt, DogBreedEnum race, string name, int age)
        {
            DogHouseId = DogHouseId;    
            IsInDogHouse = isInDogHouse;
            DepositAt = depositAt;
            Race = race;
            Name = name;
            Age = age;
        }
    }


}
