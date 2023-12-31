using System;
using System.Collections.Generic;
using System.Text;

namespace InsurancePolicyManagement.BusinessLayer.ViewModels
{
    public class InsurancePolicyViewModel
    {
        public long PolicyId { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyType { get; set; }
        public decimal PremiumAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int CustomerId { get; set; }
    }
}
