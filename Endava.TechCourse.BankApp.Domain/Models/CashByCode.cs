using Endava.TechCourse.BankApp.Domain.Common;

namespace Endava.TechCourse.BankApp.Domain.Models
{
    internal class CashByCode : BaseEntity
    {
        public string Code { get; set; }
        public decimal Amount { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}