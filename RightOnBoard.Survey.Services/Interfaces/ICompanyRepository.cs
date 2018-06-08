using RightOnBoard.Survey.Services.Entities;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RightOnBoard.Survey.Services.Interfaces
{
    public interface ICompanyRepository
    {
        List<Company> GetCompaniesForAdmin();
        Company GetCompanyInfo();
        Company GetCompanyInfoByCompanyId(string companyId);
        Department GetDepartmentInfo();
        Task<HttpStatusCode> SaveCompanyInfoByCompanyId(Company company);
        bool Find(string companyId);
        Task<HttpStatusCode> CreateCompany(Company company);
    }
}
