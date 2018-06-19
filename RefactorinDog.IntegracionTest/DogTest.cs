using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoringDog.Application.Contracts.DTOs;
using RefactoringDog.Application.Contracts.Enums;
using RefactoringDog.Application.Impl;
using RefactoringDog.Application.Literals;
using RefactoringDog.Infrastructure.Mocks;

namespace RefactorinDog.IntegracionTest
{
    [TestClass]
    public class DogTest
    {
        [TestMethod]
        public void AdoptDog_When_Username_Killer()
        {
            var dogService = new DogService(new RefactorDogMockRepository(), new TicketService());
            var message = dogService.AdoptDog(DogBreedDto.Boxer, "Dog killer");

            Assert.AreEqual(message, MessagesDogs.DogCallPolice);
        }
        [TestMethod]
        public void DepositDog_When_Dog_IsSmall()
        {
            var dalsy = new DogDto()
            {
                Name = "DALSY",
                Race = DogBreedDto.Rotweiler,
                Age = 0
            };

            var dogService = new DogService(new RefactorDogMockRepository(), new TicketService());
            var message = dogService.DepositDog(dalsy, "Esteve");

            Assert.AreEqual(message, MessagesDogs.DogSmall);
        }
        [TestMethod]
        public void DepositDog_When_Dog_IsOlder()
        {
            var dalsy = new DogDto()
            {
                Name = "DALSY",
                Race = DogBreedDto.Rotweiler,
                Age = 20
            };

            var dogService = new DogService(new RefactorDogMockRepository(), new TicketService());
            var message = dogService.DepositDog(dalsy, "Esteve");

            Assert.AreEqual(message, MessagesDogs.DogOlder);
        }
        [TestMethod]
        public void DepositDog_When_Dog_IsCallZoo()
        {
            var dalsy = new DogDto()
            {
                Name = "DALSY",
                Race = DogBreedDto.Rotweiler,
                Age = 35
            };

            var dogService = new DogService(new RefactorDogMockRepository(), new TicketService());
            var message = dogService.DepositDog(dalsy, "Esteve");

            Assert.AreEqual(message, MessagesDogs.DogCallZoo);
        }
    }
}
