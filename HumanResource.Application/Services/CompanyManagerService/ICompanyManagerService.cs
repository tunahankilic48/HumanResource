using HumanResource.Application.Models.DTOs.AccountDTO;
using HumanResource.Application.Models.DTOs.CompanyManagerDTO;
using HumanResource.Application.Models.VMs.CompanyManagerVMs;
using HumanResource.Application.Models.VMs.PersonelVM;

namespace HumanResource.Application.Services.CompanyManagerService
{
    public interface ICompanyManagerService
    {
        Task<List<EmployeeVM>> GetEmployees();
        Task<List<DepartmentVM>> GetDepartments();
        Task<List<TitleVM>> GetTitles();
        Task<CreateEmployeeVM> CreateEmployee(CreateEmployeeDTO model);
        Task UpdateEmployee(UpdateEmployeeDTO model);
        Task<List<CompanyManagerVM>> GetCompanyManagers();
        Task<bool> IsCompanyManager(string userName);
        Task<UpdateEmployeeDTO> GetByUserName(Guid id);


    }
}
