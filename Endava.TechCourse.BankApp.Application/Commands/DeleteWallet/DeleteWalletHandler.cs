using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Application.Commands.DeleteWallet
{
    public class DeleteWalletHandler : IRequestHandler<DeleteWalletCommand, CommandStatus>
    {
        private readonly ApplicationDbContext context;

        public DeleteWalletHandler(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            this.context = context;
        }

        public async Task<CommandStatus> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.Parse(request.WalletId);

            var wallet = await context.Wallets.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (wallet is null)
                return CommandStatus.Failed($"Nu exista wallet cu id ul {request.WalletId}");

            context.Wallets.Remove(wallet);
            await context.SaveChangesAsync(cancellationToken);

            return new();
        }
    }
}