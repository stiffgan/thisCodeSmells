using System;
using RefactoringDog.Application.Impl;
using RefactoringDog.Infrastructure.Mocks;
using RefactoringDogFront.Mapper;
using RefactoringDogFront.Refactor;
namespace RefactoringDogFront
{
    class Program
    {
        static void Main(string[] args)
        {
            var pluto = new DogBuilder();
            var chelsea = new DogBuilder();
            var rinTinTin = new DogBuilder();
            var lazie = new DogBuilder();
            var rex = new DogBuilder();


            pluto.WithName("Pluto").WithBreed(new DogBreed("Rotweiler")).WithAge(1);
            chelsea.WithName("Chelsea").WithBreed(new DogBreed("Boxer")).WithAge(2);
            rinTinTin.WithName("RintTinTin").WithBreed(new DogBreed("GermanShepherd")).WithAge(5).InDogHouse();
            lazie.WithName("Lazie").WithBreed(new DogBreed("Chihuahua")).WithAge(1).InDogHouse();
            rex.WithName("Rex").WithBreed(new DogBreed("GermanShepherd")).WithAge(4).InDogHouse();



            var dogService = new DogService(new RefactorDogMockRepository(), new TicketService());

            Console.WriteLine(dogService.DepositDog(DogMapper.MapDogToDto(chelsea), "Amalfi"));
            Console.WriteLine(dogService.AdoptDog(DogMapper.MapDogBreedToDto(new DogBreed("Chihuahua")), "Amalfi"));

            Console.WriteLine(dogService.DepositDog(DogMapper.MapDogToDto(pluto), "Georgina"));
            Console.WriteLine(dogService.AdoptDog(DogMapper.MapDogBreedToDto(new DogBreed("GermanShepherd")), "Georgina"));

            Console.WriteLine(dogService.AdoptDog(DogMapper.MapDogBreedToDto(new DogBreed("GermanShepherd")), "Pau"));

            Console.WriteLine(dogService.AdoptDog(DogMapper.MapDogBreedToDto(new DogBreed("Boxer")), "Dog killer Pshyco"));


            Console.Read();
        }
    }
}
