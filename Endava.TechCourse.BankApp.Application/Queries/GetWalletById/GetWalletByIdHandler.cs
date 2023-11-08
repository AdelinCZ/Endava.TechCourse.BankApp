using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Application.Queries.GetWalletById
{
    public class GetWalletByIdHandler : IRequestHandler<GetWalletByIdQuery, List<Wallet>>
    {
        private readonly ApplicationDbContext context;

        public GetWalletByIdHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Wallet>> Handle(GetWalletByIdQuery request, CancellationToken cancellationToken)
        {
            var wallet = await this.context.Wallets.Include(x => x.Id).ToListAsync(cancellationToken);
            return wallet;
        }
    }
}