using InsurancePolicyManagement.BusinessLayer.Interfaces;
using InsurancePolicyManagement.BusinessLayer.ViewModels;
using InsurancePolicyManagement.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsurancePolicyManagement.Controllers
{
    [ApiController]
    public class InsurancePolicyController : ControllerBase
    {
        private readonly IInsurancePolicyService _insurancePolicyService;
        public InsurancePolicyController(IInsurancePolicyService insurancePolicyService)
        {
            _insurancePolicyService = insurancePolicyService;
        }

        [HttpPost]
        [Route("create-policy")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateInsurancePolicy([FromBody] InsurancePolicy model)
        {
            var policyExists = await _insurancePolicyService.GetInsurancePolicyById(model.PolicyId);
            if (policyExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Insurance Policy already exists!" });
            var result = await _insurancePolicyService.CreateInsurancePolicy(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Insurance Policy creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Insurance Policy created successfully!" });

        }


        [HttpPut]
        [Route("update-policy")]
        public async Task<IActionResult> UpdateInsurancePolicy([FromBody] InsurancePolicyViewModel model)
        {
            var policy = await _insurancePolicyService.UpdateInsurancePolicy(model);
            if (policy == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Insurance Policy With Id = {model.PolicyId} cannot be found" });
            }
            else
            {
                var result = await _insurancePolicyService.UpdateInsurancePolicy(model);
                return Ok(new Response { Status = "Success", Message = "Insurance Policy updated successfully!" });
            }
        }

        [HttpDelete]
        [Route("delete-policy")]
        public async Task<IActionResult> DeleteInsurancePolicy(long id)
        {
            var policy = await _insurancePolicyService.GetInsurancePolicyById(id);
            if (policy == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Insurance Policy With Id = {id} cannot be found" });
            }
            else
            {
                var result = await _insurancePolicyService.DeleteInsurancePolicyById(id);
                return Ok(new Response { Status = "Success", Message = "Insurance policy deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-policy-by-id")]
        public async Task<IActionResult> GetInsurancePolicyById(long id)
        {
            var policy = await _insurancePolicyService.GetInsurancePolicyById(id);
            if (policy == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Insurance Policy With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(policy);
            }
        }

        [HttpGet]
        [Route("get-all-policies")]
        public async Task<IEnumerable<InsurancePolicy>> GetAllPolicies()
        {
            return _insurancePolicyService.GetAllInsurancePolicies();
        }
    }
}