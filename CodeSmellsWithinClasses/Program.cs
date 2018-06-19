using System;
using RefactoringDogFront.Enum;
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

            pluto.WithName("Pluto").WithBreed(DogBreedEnum.Rotweiler).WithAge(1);
            chelsea.WithName("Chelsea").WithBreed(DogBreedEnum.Boxer).WithAge(2);
            rinTinTin.WithName("RintTinTin").WithBreed(DogBreedEnum.GermanShepherd).WithAge(5).InDogHouse();
            lazie.WithName("Lazie").WithBreed(DogBreedEnum.Chihuahua).WithAge(1).InDogHouse();
            rex.WithName("Rex").WithBreed(DogBreedEnum.GermanShepherd).WithAge(4).InDogHouse();



            var dogService = new DogService(new RefactorDogMockRepository(), new TicketService());

            Console.WriteLine(dogService.DepositDog(DogMapper.MapDogToDto(chelsea), "Amalfi"));
            Console.WriteLine(dogService.AdoptDog(DogMapper.MapDogBreedToDto(DogBreedEnum.Chihuahua), "Amalfi"));

            Console.WriteLine(dogService.DepositDog(DogMapper.MapDogToDto(pluto), "Georgina"));
            Console.WriteLine(dogService.AdoptDog(DogMapper.MapDogBreedToDto(DogBreedEnum.GermanShepherd), "Georgina"));

            Console.WriteLine(dogService.AdoptDog(DogMapper.MapDogBreedToDto(DogBreedEnum.GermanShepherd), "Pau"));

            Console.WriteLine(dogService.AdoptDog(DogMapper.MapDogBreedToDto(DogBreedEnum.Boxer), "Dog killer Pshyco"));


            Console.Read();
        }
    }
}
