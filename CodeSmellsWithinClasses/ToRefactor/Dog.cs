using System;

namespace CodeSmellsWithinClasses.ToRefactor
{
    public class Dog
    {
        public Guid DogHouseId { get; set; }
        public bool IsInDogHouse { get; set; }
        public DateTime DepositAt { get; set; }

        public DogBreedEnum Race { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Desc()
        {
            return string.Format("{0}. {1}. {2} years. ", this.Name, this.Race, this.Age);
        }

        //Calculate the months in the DogHouse.
        public int HowLogInDogHouse()
        {
            int months = 0;
            if (!this.IsInDogHouse)
            {
                //i found it on stacoverflow suck it!!
                months = (DateTime.UtcNow.Month - this.DepositAt.Month) + 12 * (DateTime.UtcNow.Year - this.DepositAt.Year);
            }
            return months;
        }
    }
}