using Endava.TechCourse.BankApp.Domain.Common;

namespace Endava.TechCourse.BankApp.Domain.Models
{
    internal class Currency : BaseEntity
    {
        public decimal Name { get; set; }
        public decimal ChangeRate { get; set; }
        public string CurrencyCode { get; set; }
    }
}