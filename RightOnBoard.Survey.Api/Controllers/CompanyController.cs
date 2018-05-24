using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RightOnBoard.Survey.Api.Models;
using RightOnBoard.Survey.Services.Interfaces;

namespace RightOnBoard.Survey.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        //Get/Survey
        [HttpGet]
        [Route("getcompanyInfo")]
        public Company CompanyInfo()
        {
            var companyInfo = _companyRepository.GetCompanyInfo();

            return new Company
            {
                CompanyId = companyInfo.CompanyId,
                CompanyName = companyInfo.CompanyName
            };
        }

        [HttpGet]
        [Route("getdeptlist")]
        public Department DepartmentInfo()
        {
            return new Department { };
        }
    }
}