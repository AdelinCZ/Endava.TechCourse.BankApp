using Endava.TechCourse.BankApp.Application.Queries.GetWallets;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using Endava.TechCourse.BankApp.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Endava.TechCourse.BankApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMediator mediator;

        public WalletController(ApplicationDbContext context, IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(mediator);

            this.mediator = mediator;
            this.context = context;
        }

        [HttpPost]
        public IActionResult CreateWallet([FromBody] CreateWalletDTO createWalletDto)
        {
            var wallet = new Wallet
            {
                Type = createWalletDto.Type,
                Amount = createWalletDto.Amount,
                Currency = new Currency
                {
                    Name = "EUR",
                    CurrencyCode = "EUR",
                    ChangeRate = 20
                }
            };

            context.Wallets.Add(wallet);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public async Task<List<WalletDto>> GetWallets()
        {
            var query = new GetWalletsQuery();
            var wallets = await mediator.Send(query);

            return new();
        }
    }
}