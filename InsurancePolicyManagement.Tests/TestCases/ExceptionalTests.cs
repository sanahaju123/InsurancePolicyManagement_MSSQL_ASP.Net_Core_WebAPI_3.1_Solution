

using InsurancePolicyManagement.BusinessLayer.Interfaces;
using InsurancePolicyManagement.BusinessLayer.Services.Repository;
using InsurancePolicyManagement.BusinessLayer.Services;
using InsurancePolicyManagement.BusinessLayer.ViewModels;
using InsurancePolicyManagement.Entities;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace InsurancePolicyManagement.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IInsurancePolicyService _insuranceService;
        public readonly Mock<IInsurancePolicyRepository> insuranceservice = new Mock<IInsurancePolicyRepository>();

        private readonly InsurancePolicy _insurancePolicy;
        private readonly InsurancePolicyViewModel _insurancePolicyViewModel;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
        {
            _insuranceService = new InsurancePolicyService(insuranceservice.Object);

            _output = output;

            _insurancePolicy = new InsurancePolicy
            {
                PolicyId = 1,
                CustomerId = 11,
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                IsActive = true,
                PolicyNumber = "HI123",
                PolicyType = "Home Insurance",
                PremiumAmount = 12000
            };

            _insurancePolicyViewModel = new InsurancePolicyViewModel
            {
                PolicyId = 1,
                CustomerId = 11,
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                IsActive = true,
                PolicyNumber = "HI123",
                PolicyType = "Home Insurance",
                PremiumAmount = 12000
            };
        }


        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidPolicyIdIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                insuranceservice.Setup(repo => repo.CreateInsurancePolicy(_insurancePolicy)).ReturnsAsync(_insurancePolicy);
                var result = await  _insuranceService.CreateInsurancePolicy(_insurancePolicy);
                if (result != null || result.PolicyId !=0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidPolicyNumberIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                insuranceservice.Setup(repo => repo.CreateInsurancePolicy(_insurancePolicy)).ReturnsAsync(_insurancePolicy);
                var result = await _insuranceService.CreateInsurancePolicy(_insurancePolicy);
                if (result != null || result.PolicyNumber != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}
