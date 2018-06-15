using RightOnBoard.JwtAuthTokenServer.Service.Interfaces;
using RightOnBoard.Survey.Data.DbContext;
using RightOnBoard.Survey.Services.Entities;
using RightOnBoard.Survey.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RightOnBoard.Survey.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private ApplicationDbContext _dbContext;
        private IUserService _userService;

        public CompanyRepository(ApplicationDbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public List<Company> GetCompaniesForAdmin()
        {
            var userId = _userService.GetCurrentUserId();

            var companyList = (from comp in _dbContext.Company
                                where !_dbContext.Customers.Any(res=>(comp.CompanyId == res.CompanyId &&  res.UserId == userId))
                               select new Company
                               {
                                   CompanyId = comp.CompanyId,
                                   CompanyName = comp.CompanyName
                               }).ToList();

            return companyList;
        }

        public Company GetCompanyInfo()
        {
            var userId = _userService.GetCurrentUserId();

            var companyInfo = (from cust in _dbContext.Customers
                               join comp in _dbContext.Company on cust.CompanyId equals comp.CompanyId
                               where cust.UserId == userId
                               select new Company
                               {
                                   CompanyId = comp.CompanyId,
                                   CompanyName = comp.CompanyName
                               }).FirstOrDefault();

            return companyInfo;
        }

        public Company GetCompanyInfoByCompanyId(string companyId)
        {
            //var userId = _userService.GetCurrentUserId();

            //var companyInfo = (from cust in _dbContext.Customers
            //                   join comp in _dbContext.Company on cust.CompanyId equals comp.CompanyId
            //                   where comp.CompanyId == companyId
            //                   select new Company
            //                   {
            //                       CompanyId = comp.CompanyId,
            //                       CompanyName = comp.CompanyName
            //                   }).FirstOrDefault();

            var companyInfo = (from comp in _dbContext.Company 
                               where comp.CompanyId == companyId
                               select new Company
                               {
                                   CompanyId = comp.CompanyId,
                                   CompanyName = comp.CompanyName
                               }).FirstOrDefault();

            return companyInfo;
        }

        public async Task<HttpStatusCode> SaveCompanyInfoByCompanyId(Company company)
        {
            var result = _dbContext.Entry(new Data.Models.Company
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName
            }).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            if (result == Microsoft.EntityFrameworkCore.EntityState.Modified)
                return HttpStatusCode.OK;
            else
                return HttpStatusCode.BadRequest;
        }

        public async Task<HttpStatusCode> CreateCompany(Company company)
        {
            //var userId = _userService.GetCurrentUserId();

            //var companyInfo = (from cust in _dbContext.Customers
            //                   where cust.UserId == userId
            //                   select new Company
            //                   {
            //                       CompanyId = cust.CompanyId,
            //                       CompanyName = company.CompanyName
            //                   }).SingleOrDefault();

            var insertCompany = _dbContext.Company.Add(new Data.Models.Company
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName
            });

            if (insertCompany.State == Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                await _dbContext.SaveChangesAsync();

                return HttpStatusCode.OK;
            }
            else
              return HttpStatusCode.BadRequest;
        }

        public Department GetDepartmentInfo()
        {
            throw new System.NotImplementedException();
        }

        public bool Find(string companyId)
        {
            bool isCompanyExists = _dbContext.Company.Any(x => x.CompanyId == companyId || x.CompanyName == companyId);

            return isCompanyExists;
        }

        //public Department GetDepartmentInfo()
        //{
        //    var deptInfo = (from 
        //}
    }
}
