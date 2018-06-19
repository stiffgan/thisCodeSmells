using RefactoringDog.Application.Contracts.DTOs;

namespace RefactoringDog.Application.Contracts
{
    public interface ITicketService
    {
        string GetTicket(string userName, DogDto dog, double price, string action);
    }
}
