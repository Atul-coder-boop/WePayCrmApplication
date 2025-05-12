using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Core.Entities
{
    public class FreshLeads
    {
        public string CustomerId { get; set; }
        public string  CustomerName { get; set; }
        public string  Email { get; set; }
        public string  PhoneNo { get; set; }
        public string  LoanRequired { get; set; }
        public string  Purpose { get; set; }
        public string  Tenure { get; set; }
        public string  MonthlyIncome { get; set; }
        public string  SalaryMode { get; set; }
        public string  city { get; set; }
        public int State { get; set; }
        public int PinCode { get; set; }
        public string  UtmSource { get; set; }
        public string  Domain { get; set; }
        public string  Status { get; set; }
        public string  IP { get; set; }
        public string  LoanCount { get; set; }
        public string GCLID { get; set; }
        public string ConversionName { get; set; }
        public int LeadAssigneeId { get; set; } =0;
        public int CreditManagerId { get; set; } = 0;

        public string CallerName { get; set; }
        public string CredMgrName { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

    }

   public class UpdateLonaRequest()
    {
        public string Purpose { get; set; }
        public string MonthlyIncome { get; set; }
        public string LoanRequired { get; set; }
        public string city { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
    }
}
