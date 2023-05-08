using HumanResource.Application.Models.VMs.CompanyManagerVMs;
using HumanResource.Application.Models.VMs.PersonelVM;

namespace HumanResource.Application.Services.CompanyManagerService
{
    public interface ICompanyManagerService
    {
        Task<List<EmployeeVM>> GetEmployees();
        Task<List<DepartmentVM>> GetDepartments();
    }
}
