using Endava.TechCourse.BankApp.Domain.Common;

namespace Endava.TechCourse.BankApp.Domain.Models
{
    internal class Wallet : BaseEntity
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        public string Type { get; set; }
    }
}