using Endava.TechCourse.BankApp.Domain.Common;

namespace Endava.TechCourse.BankApp.Domain.Models
{
    internal class Report : BaseEntity
    {
        public DateTime ReportDate { get; set; }
        public decimal BeginningBalance { get; set; }
        public decimal EndingBalance { get; set; }
    }
}