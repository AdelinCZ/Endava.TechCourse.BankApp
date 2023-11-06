using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Application.Commands.DeleteCurrency
{
    public class DeleteCurrencyHandler : IRequestHandler<DeleteCurrencyCommand, CommandStatus>
    {
        private readonly ApplicationDbContext context;

        public DeleteCurrencyHandler(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this.context = context;
        }

        public async Task<CommandStatus> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.Parse(request.CurrencyId);

            var currency = await context.Currencies.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (currency is null)
                return CommandStatus.Failed($"Nu exista o valuta cu id ul {request.CurrencyId}");

            context.Currencies.Remove(currency);
            await context.SaveChangesAsync(cancellationToken);

            return new();
        }
    }
}