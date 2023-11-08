using Endava.TechCourse.BankApp.Application.Commands.AddCurrency;
using Endava.TechCourse.BankApp.Application.Commands.DeleteCurrency;
using Endava.TechCourse.BankApp.Application.Queries.GetCurrencies;
using Endava.TechCourse.BankApp.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Endava.TechCourse.BankApp.Server.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyContoller : ControllerBase
    {
        private readonly IMediator mediator;

        public CurrencyContoller(IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator);
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<CurrencyDto>> GetCurrencies()
        {
            var query = new GetCurrenciesQuery();
            var currencies = await mediator.Send(query);

            var dtos = new List<CurrencyDto>();
            foreach (var currency in currencies)
            {
                var currencyDto = new CurrencyDto
                {
                    Name = currency.Name,
                    CurrencyCode = currency.CurrencyCode,
                    ChangeRate = currency.ChangeRate,
                };
                dtos.Add(currencyDto);
            }

            return dtos;
        }

        [HttpPost]
        public async Task<ActionResult> AddCurrency([FromBody] CurrencyDto dto)
        {
            var command = new AddCurrencyCommand()
            {
                Name = dto.Name,
                CurrencyCode = dto.CurrencyCode,
                ChangeRate = dto.ChangeRate,
            };
            var result = await mediator.Send(command);

            if (result.IsSuccessful)
            {
                return Ok();
            }
            else return BadRequest(result.Error);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteCurrency([FromBody] string id)
        {
            var command = new DeleteCurrencyCommand()
            {
                CurrencyId = id
            };

            var result = await this.mediator.Send(command);
            if (result.IsSuccessful)
            {
                return Ok();
            }
            else { return BadRequest(result.Error); }
        }
    }
}