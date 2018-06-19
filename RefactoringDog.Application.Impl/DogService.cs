using System;
using RefactoringDog.Application.Contracts;
using RefactoringDog.Application.Contracts.DTOs;
using RefactoringDog.Application.Contracts.Enums;
using Microsoft.VisualBasic;
using RefactoringDog.Infrastructure.Contracts;
using RefactoringDog.Application.Impl.Mappers;
using RefactoringDog.Application.Literals;
using System.Linq;


namespace RefactoringDog.Application.Impl
{
    public class DogService : IDogService
    {
        const double tax = 2.0;
        private readonly IRefactorDogRepository _refactorDogRepository;
        private readonly ITicketService _ticketService;
        public DogService(IRefactorDogRepository refactorDogRepository, ITicketService ticketService)
        {
            _refactorDogRepository = refactorDogRepository;
            _ticketService = ticketService;
        }

        public string AdoptDog(DogBreedDto raceDto, string userName)
        {

            if (userName.Contains(MessagesDogs.DogKiller))
            {
                return MessagesDogs.DogCallPolice;
            }

            var dog = _refactorDogRepository.AdoptDog(DogMapper.MapDogBreedToEntity(raceDto));

            if (dog == null)
            {
                return MessagesDogs.DogNotHave;
            }

            var dogDto = DogMapper.MapDogToDto(dog);

            return _ticketService.GetTicket(userName, dogDto, GetCostAdopt(dogDto), MessagesDogs.DogAdopting); ;
        }

        public string DepositDog(DogDto dogDto, string userName)
        {
            if (_refactorDogRepository.GetDogs().Count() >= 100)
            {
                return MessagesDogs.DogFull;
            }

            if (dogDto.Name.Contains(MessagesDogs.DogPeopeEater))
            {
                return MessagesDogs.DogDangerous;
            }

            if (dogDto.Age < 1)
            {
                return MessagesDogs.DogSmall;
            }
            if (dogDto.Age > 30)
            {
                return MessagesDogs.DogCallZoo;
            }
            if (dogDto.Age > 10)
            {
                return MessagesDogs.DogOlder;
            }


            dogDto.DogHouseId = Guid.NewGuid();
            dogDto.IsInDogHouse = true;
            dogDto.DepositAt = DateTime.UtcNow;

            _refactorDogRepository.DepositDog(DogMapper.MapDogToEntity(dogDto));

            return _ticketService.GetTicket(userName, dogDto, GetCostDeposit(dogDto), MessagesDogs.DogDepositing); ;
        }

        private double GetCostAdopt(DogDto dog)
        {
            var adoptPrice = 0.0;
            if (dog.Race != DogBreedDto.Chihuahua)
            {
                adoptPrice = HowLongInDogHouse(dog) * tax;
            }
            return adoptPrice;
        }

        private double GetCostDeposit(DogDto dog)
        {
            return (10 * dog.Age) * tax;
        }

        private int HowLongInDogHouse(DogDto dog)
        {
            var months = 0;
            if (!dog.IsInDogHouse)
            {
                months = (int)(DateAndTime.DateDiff(DateInterval.Month, dog.DepositAt, DateTime.UtcNow));
            }
            return months;
        }
    }
}
