using RightOnBoard.Survey.Services.Entities;

namespace RightOnBoard.Survey.Services.Interfaces
{
    public interface ICompanyRepository
    {
        Company GetCompanyInfo();
        Department GetDepartmentInfo();
    }
}
