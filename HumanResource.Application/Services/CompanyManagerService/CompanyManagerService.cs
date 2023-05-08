using HumanResource.Application.Models.VMs.CompanyManagerVMs;
using HumanResource.Application.Models.VMs.PersonelVM;
using HumanResource.Application.Services.AccountServices;
using HumanResource.Domain.Enums;
using HumanResource.Domain.Repositories;
using HumanResource.Domain.Repositries;
using HumanResource.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Application.Services.CompanyManagerService
{
    internal class CompanyManagerService : ICompanyManagerService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITitleRepository _titleRepository;
        private readonly IAppUserRepository _appUserRepository;
        public CompanyManagerService(IDepartmentRepository departmentRepository, ITitleRepository titleRepository, IAppUserRepository appUserRepository)
        {
            _departmentRepository = departmentRepository;
            _titleRepository = titleRepository;
            _appUserRepository = appUserRepository;
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

        public async Task<List<EmployeeVM>> GetEmployees()
        {
            var employees = await _appUserRepository.GetFilteredList(
              select: x => new EmployeeVM()
              {
                  Id = x.Id,
                  FullName = x.FirstName + " " + x.LastName,
                  DepartmentName = x.Department.Name,
                  Title = x.Title.Name

              },
              where: x=>x.StatuId == Status.Active.GetHashCode(),
              orderby: x => x.OrderByDescending(x => x.CreatedDate),
              include: x => x.Include(x => x.Department).Include(x=>x.Title)
              );

            return employees;
        }

        public async Task<List<TitleVM>> GetTitles()
        {
            var titles = await _titleRepository.GetFilteredList(
             select: x => new TitleVM()
             {
                 Id = x.Id,
                 Name = x.Name

             },
             where: x => x.StatuId == Status.Active.GetHashCode(),
             orderby: x => x.OrderByDescending(x => x.Name)
             );

            return titles;
        }
    }
}
