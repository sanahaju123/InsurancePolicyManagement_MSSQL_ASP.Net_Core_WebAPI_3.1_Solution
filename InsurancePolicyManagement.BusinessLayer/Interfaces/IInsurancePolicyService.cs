using InsurancePolicyManagement.BusinessLayer.ViewModels;
using InsurancePolicyManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePolicyManagement.BusinessLayer.Interfaces
{
    public interface IInsurancePolicyService
    {
        List<InsurancePolicy> GetAllInsurancePolicies();
        Task<InsurancePolicy> CreateInsurancePolicy(InsurancePolicy insurancePolicy);
        Task<InsurancePolicy> GetInsurancePolicyById(long id);
        Task<bool> DeleteInsurancePolicyById(long id);
        Task<InsurancePolicy> UpdateInsurancePolicy(InsurancePolicyViewModel model);
    }
}
