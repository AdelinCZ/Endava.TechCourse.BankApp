using Endava.TechCourse.BankApp.Domain.Common;

namespace Endava.TechCourse.BankApp.Shared
{
    internal class Transaction : BaseEntity
    {
        public int TransactionId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}