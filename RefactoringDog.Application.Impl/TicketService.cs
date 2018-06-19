using System;
using RefactoringDog.Application.Contracts;
using RefactoringDog.Application.Contracts.DTOs;
using RefactoringDog.Application.Literals;

namespace RefactoringDog.Application.Impl
{
    public class TicketService : ITicketService
    {
        public string GetTicket(string userName, DogDto dog, double price, string action)
        {
            var messageTicket = string.Concat(MessagesDogs.DogSeparator, Environment.NewLine,
                                string.Format(MessagesDogs.DogTicket, userName, action), Environment.NewLine,
                                string.Format(MessagesDogs.DogDescription, dog.Description), Environment.NewLine,
                                string.Format(MessagesDogs.DogPayCashRegister, price), Environment.NewLine,
                                MessagesDogs.DogSeparator, Environment.NewLine);

            return messageTicket;
        }
    }
}
