using Endava.TechCourse.BankApp.Application.Queries.GetCurrencies;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using Endava.TechCourse.BankApp.Test.Common;

namespace Endava.TechCourse.BankApp.Test.QueriesTests
{
    public class GetCurrenciesHandlerTest
    {
        [Test, ApplicationData]
        public async Task ShouldGetCurrencies(
            [Frozen] ApplicationDbContext context,
            GetCurrenciesQuery query,
            GetCurrenciesHandler handler,
            Currency firstCurrency,
            Currency secondCurrency)
        {
            context.Currencies.AddRange(firstCurrency, secondCurrency);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            var result = await handler.Handle(query, default);

            result.Count.Should().Be(2);
        }
    }
}