using RefactoringDogFront.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringDogFront.Refactor
{
    public class DogBuilder
    {
        private Guid dogHouseId;
        private bool isInDogHouse;
        private DateTime depositAt;
        private DogBreedEnum race;
        private string name;
        private int age;

        public static implicit operator Dog(DogBuilder builder)
        {
            return new Dog(
                builder.dogHouseId,
                builder.isInDogHouse,
                builder.depositAt,
                builder.race,
                builder.name,
                builder.age);
        }

        public DogBuilder InDogHouse()
        {
            isInDogHouse = true;
            depositAt = DateTime.UtcNow.AddMonths(-(new Random().Next(0, 24)));
            dogHouseId = Guid.NewGuid();
            return this;
        }

        public DogBuilder WithDogHouseId(Guid dogHouseId)
        {
            this.dogHouseId = dogHouseId;
            return this;
        }

        public DogBuilder WithIsInDogHouse(bool isInDogHouse)
        {
            this.isInDogHouse = isInDogHouse;
            return this;
        }

        public DogBuilder WithDepositAt(DateTime depositAt)
        {
            this.depositAt = depositAt;
            return this;
        }

        public DogBuilder WithBreed(DogBreedEnum race)
        {
            this.race = race;
            return this;
        }

        public DogBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }

        public DogBuilder WithAge(int age)
        {
            this.age = age;
            return this;
        }
    }
}
