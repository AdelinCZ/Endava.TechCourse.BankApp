using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using Endava.TechCourse.BankApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WalletController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
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

            _context.Wallets.Add(wallet);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("getwallets")]
        public async Task<List<Wallet>> GetWallets()
        {
            return await _context.Wallets.ToListAsync();
        }
    }
}