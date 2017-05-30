using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSmellsWithinClasses.ToRefactor
{
    public class DogHouse
    {
        public List<Dog> Dogs = new List<Dog>();

        public string Deposit(string userName, Dog dog)
        {
            string validationMessage = "";

            if (dog.Age < 1)
            {
                validationMessage = "The dog its to small to be Deposit. Come back when the dog were older than 1 year.";
            }
            else if (dog.Age > 30)
            {
                validationMessage = "WTF this not suppouse to be alive???. I will call the Zoo";
            }
            else if (dog.Age > 10)
            {
                validationMessage = "The dog its to older to be Deposit. Dont come back.";
            }
            else if (dog.Name.Contains("People eater"))
            {
                validationMessage = "The dog its to danguerous to be Deposit. Dont come back.";
            }
            else if (this.Dogs.Count >= 100)
            {
                validationMessage = "We are full :(. Why dont you Adopt one";
            }
            else
            {
                //All ok! the dog its fine
            }

            if (!string.IsNullOrEmpty(validationMessage))
            {
                //something went wrong with this dog
                return validationMessage;
            }

            var price = this.Calculate(dog);
            this.SetIdToDog(dog);

            //Put the dog into its cage
            this.Dogs.Add(dog);

            var ticket = "------------------------------------------------------------------------------------" + Environment.NewLine;
            ticket += string.Format("Dear {0} this is the ticket conforming you are Depositing a dog to us.", userName) + Environment.NewLine;
            ticket += string.Format("The dog its {0}", dog.Desc()) + Environment.NewLine;
            ticket += string.Format("You must pay: {0} on the cash register", price) + Environment.NewLine;
            ticket += "------------------------------------------------------------------------------------" + Environment.NewLine;

            return ticket;
        }

        public string Adopt(string userName, DogBreedEnum raceEnum)
        {
            string validationMessage = "";

            if (!this.Dogs.Any(x => x.Race == raceEnum))
            {
                validationMessage = "We dont have the dog you want";
            }
            else if (userName.Contains("Dog killer"))
            {
                validationMessage = "I will call Police";
            }

            if (!string.IsNullOrEmpty(validationMessage))
            {
                //something went wrong whit this user
                return validationMessage;
            }

            var dog = this.Dogs.FirstOrDefault(x => x.Race == raceEnum);
            var price = this.Calculate2(dog);

            var ticket = "------------------------------------------------------------------------------------" + Environment.NewLine;
            ticket += string.Format("Dear {0} this is the ticket conforming you are Adopting a dog to us.", userName) + Environment.NewLine;
            ticket += string.Format("The dog its {0}", dog.Desc()) + Environment.NewLine;
            ticket += string.Format("You must pay: {0} on the cash register", price) + Environment.NewLine;
            ticket += "------------------------------------------------------------------------------------" + Environment.NewLine;

            return ticket;
        }

        //Calculate the cost of Deposit a Dog
        private double Calculate(Dog dog)
        {
            double depositPriceDouble;
            
            switch (dog.Race)
            {
                //Big dogs are expensive to mantain
                case DogBreedEnum.Boxer:
                case DogBreedEnum.Bulldog:
                case DogBreedEnum.Rotweiler:
                case DogBreedEnum.GermanShepherd:
                    var bigDogPrice = (10 * dog.Age) * 2.0; //2.0 its the IVA
                    depositPriceDouble = bigDogPrice;
                    break;
                case DogBreedEnum.Chihuahua:
                    var smallDogPrice = (10 * dog.Age) * 2.0;
                    depositPriceDouble = smallDogPrice;
                    break;
                default:
                    var normalDogPrice = (10 * dog.Age) * 2.0;
                    depositPriceDouble = normalDogPrice;
                    break;
            }

            //return the price
            return depositPriceDouble;
        }

        //Calculate the cost of Adopt a Dog
        private double Calculate2(Dog dog)
        {
            double depositPriceDouble;

            switch (dog.Race)
            {
                //Its ugly and noisy its free
                case DogBreedEnum.Chihuahua:
                    depositPriceDouble = 0;
                    break;
                default:
                    var normalDogPrice = dog.HowLongInDogHouse() * 2.0; //2.0 its the IVA
                    depositPriceDouble = normalDogPrice;
                    break;
            }

            //return the price
            return depositPriceDouble;
        }

        private void SetIdToDog(Dog dog)
        {
            dog.DogHouseId = Guid.NewGuid();
            //if we are setting Id its becouse we are going to Deposit so we set flag to true.
            dog.IsInDogHouse = true;
            dog.DepositAt = DateTime.UtcNow;

            //this.RenameDog(dog);
        }

        private void RenameDog(Dog dog)
        {
            dog.Name = dog.Name + " is on Deposit now :(";
        }
    }
}