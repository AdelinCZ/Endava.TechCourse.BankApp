using Endava.TechCourse.BankApp.Domain.Models;
using MediatR;

namespace Endava.TechCourse.BankApp.Application.Queries.GetWalletById
{
    public class GetWalletByIdQuery : IRequest<List<Wallet>>
    {
    }
}