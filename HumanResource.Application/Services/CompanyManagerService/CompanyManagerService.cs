using HumanResource.Application.Models.VMs.CompanyManagerVMs;
using HumanResource.Application.Models.VMs.PersonelVM;
using HumanResource.Domain.Enums;
using HumanResource.Domain.Repositries;

namespace HumanResource.Application.Services.CompanyManagerService
{
    internal class CompanyManagerService : ICompanyManagerService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public CompanyManagerService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<List<DepartmentVM>> GetDepartments()
        {
            var departments = await _departmentRepository.GetFilteredList(
              select: x => new DepartmentVM()
              {
                  Id = x.Id,
                  Name = x.Name

              },
              where: x=>x.StatuId == Status.Active.GetHashCode(),
              orderby: x => x.OrderByDescending(x => x.Name)
              );

            return departments;
        }

        public Task<List<EmployeeVM>> GetEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
