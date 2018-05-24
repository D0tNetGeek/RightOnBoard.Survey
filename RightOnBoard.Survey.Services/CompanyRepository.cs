using RightOnBoard.JwtAuthTokenServer.Service.Interfaces;
using RightOnBoard.Survey.Data.DbContext;
using RightOnBoard.Survey.Services.Entities;
using RightOnBoard.Survey.Services.Interfaces;
using System.Linq;

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

        public Department GetDepartmentInfo()
        {
            throw new System.NotImplementedException();
        }

        //public Department GetDepartmentInfo()
        //{
        //    var deptInfo = (from 
        //}
    }
}
