using Endava.TechCourse.BankApp.Application.Commands.DeleteWallet;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using Endava.TechCourse.BankApp.Test.Common;

namespace Endava.TechCourse.BankApp.Test.CommandsTests
{
    public class DeleteWalletsHandlerTests
    {
        [Test, ApplicationData]
        public async Task ShoudDeleteWallet(
            [Frozen] ApplicationDbContext context,
            DeleteWalletCommand command,
            DeleteWalletHandler handler,
            Wallet wallet)
        {
            //Arrange
            command.WalletId = wallet.Id.ToString();
            context.Wallets.Add(wallet);
            await context.SaveChangesAsync();
            context.ChangeTracker.Clear();

            //ACT

            await handler.Handle(command, default);

            //Assert

            context.Wallets.Should().BeEmpty();
        }
    }
}