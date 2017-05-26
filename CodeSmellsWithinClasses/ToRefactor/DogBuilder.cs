using System;

namespace CodeSmellsWithinClasses.ToRefactor
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
            return new Dog
            {
                DogHouseId = builder.dogHouseId,
                IsInDogHouse = builder.isInDogHouse,
                DepositAt = builder.depositAt,
                Race = builder.race,
                Name = builder.name,
                Age = builder.age
            };
        }

        public DogBuilder InDogHouse()
        {
            this.isInDogHouse = true;
            this.depositAt = DateTime.UtcNow.AddMonths(-(new Random().Next(0, 24)));
            this.dogHouseId = Guid.NewGuid();
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