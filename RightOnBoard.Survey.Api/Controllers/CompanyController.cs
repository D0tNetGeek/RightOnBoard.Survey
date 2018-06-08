using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RightOnBoard.Survey.Api.Models;
using RightOnBoard.Survey.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RightOnBoard.Survey.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        //Get/CompaniesList
        [HttpGet]
        [Route("getcompanieslistforadmin")]
        public List<Company> CompaniesListForAdmin()
        {
            var companiesList = _companyRepository.GetCompaniesForAdmin();

            return (from cl in companiesList
                    select new Company
                    {
                        CompanyId = cl.CompanyId,
                        CompanyName = cl.CompanyName
                    }).ToList();
        }

        //Get/CompanyInfo
        [HttpGet]
        //[ValidateAntiForgeryToken]
        //[IgnoreAntiforgeryToken]
        [Route("getcompanyinfo")]
        public Company CompanyInfo()
        {
            var companyInfo = _companyRepository.GetCompanyInfo();

            return new Company
            {
                CompanyId = companyInfo.CompanyId,
                CompanyName = companyInfo.CompanyName
            };
        }

        //Get/CompanyInfoByCompanyId
        [HttpGet]
        [Route("getcompanyinfobycompanyid")]
        public Company CompanyInfoByCompanyId(string companyId)
        {
            var companyInfo = _companyRepository.GetCompanyInfoByCompanyId(companyId);

            return new Company
            {
                CompanyId = companyInfo.CompanyId,
                CompanyName = companyInfo.CompanyName
            };
        }

        [IgnoreAntiforgeryToken]
        [HttpPost]
        [Route("savecompanyinfo")]
        public async Task<IActionResult> SaveCompanyInfo([FromBody]Company company)
        {
            var isCompanyExists = _companyRepository.Find(company.CompanyId);

            if (!isCompanyExists)
            {
                return BadRequest();
            }

            var result = await _companyRepository.SaveCompanyInfoByCompanyId(new Services.Entities.Company
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName
            });

            if (result == HttpStatusCode.OK)
                return Ok(result);
            else
                return BadRequest();
        }

        [IgnoreAntiforgeryToken]
        [HttpPut]
        [Route("createcompany")]
        public async Task<IActionResult> CreateCompany([FromBody] Company company)
        {
            var isCompanyNameExists = _companyRepository.Find(company.CompanyName);

            if (isCompanyNameExists)
            {
                return BadRequest();
            }
            var result = await _companyRepository.CreateCompany(new Services.Entities.Company
            {
                CompanyId = Guid.NewGuid().ToString(),
                CompanyName = company.CompanyName
            });

            if (result == HttpStatusCode.OK)
                return Ok(result);
            else
                return
                    BadRequest();
        }
    }
}