using Endava.TechCourse.BankApp.Application.Commands.DeleteCurrency;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using Endava.TechCourse.BankApp.Test.Common;

namespace Endava.TechCourse.BankApp.Test.CommandsTests
{
    public class DeleteCurrenciesHandlerTests
    {
        [Test, ApplicationData]
        public async Task ShouldDeleteCurrency(
            [Frozen] ApplicationDbContext context,
            DeleteCurrencyHandler handler,
            DeleteCurrencyCommand command,
            Currency currency)
        {
            //Arange
            command.CurrencyId = currency.Id.ToString();
            context.Currencies.Add(currency);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            //Act
            await handler.Handle(command, default);

            //Assert
            context.Currencies.Should().BeEmpty();
        }
    }
}