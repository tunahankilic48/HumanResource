using AutoMapper;
using HumanResource.Application.Models.DTOs.CompanyManagerDTO;
using HumanResource.Application.Models.VMs.CompanyManagerVMs;
using HumanResource.Application.Models.VMs.PersonelVM;
using HumanResource.Application.Services.PersonelService;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Enums;
using HumanResource.Domain.Repositories;
using HumanResource.Domain.Repositries;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Application.Services.CompanyManagerService
{
    internal class CompanyManagerService : ICompanyManagerService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITitleRepository _titleRepository;
        private readonly IAppUserRepository _appUserRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IPersonelService _personelService;
        public CompanyManagerService(IDepartmentRepository departmentRepository, ITitleRepository titleRepository, IMapper mapper, UserManager<AppUser> userManager, IAppUserRepository appUserRepository, IPersonelService personelService)
        {
            _departmentRepository = departmentRepository;
            _titleRepository = titleRepository;
            _mapper = mapper;
            _userManager = userManager;
            _appUserRepository = appUserRepository;
            _personelService = personelService;
        }

        public async Task<CreateEmployeeVM> CreateEmployee(CreateEmployeeDTO model)
        {
            AppUser newEmployee = _mapper.Map<AppUser>(model);
            if (model.Image != null)
            {
                using var image = Image.Load(model.Image.OpenReadStream());

                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/media/images/{guid}.jpg");

                newEmployee.ImagePath = $"/media/images/{guid}.jpg";
            }
            else
                newEmployee.ImagePath = model.ImagePath;
            newEmployee.Address = new Address()
            {
                CreatedDate = DateTime.Now,
                Description = model.AddressDescription,
                DistrictId = model.DistrictId,
            };
            var password = new Random().Next(100000, 9999990).ToString();
            try
            {
                await _userManager.CreateAsync(newEmployee, password);

            }
            catch (Exception ex)
            {
                 var abc = ex.Message;
                var bca = abc;
                throw;
            }

            IdentityResult result = await _userManager.AddToRoleAsync(newEmployee, "Employee");
            CreateEmployeeVM createEmployee = new CreateEmployeeVM();
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(newEmployee);
                createEmployee.Email = newEmployee.Email;
                createEmployee.Token = token;
                createEmployee.Result = result;
                createEmployee.Password = password;
            }
            else
            {

                createEmployee.Result = result;
            }
            return createEmployee;
        }

        public async Task<List<CompanyManagerVM>> GetCompanyManagers()
        {
            var companyPersonels = await _appUserRepository.GetFilteredList(
              select: x => new CompanyManagerVM()
              {
                  Id = x.Id,
                  FullName = x.FirstName + " " + x.LastName,
                  UserName = x.UserName

              },
              where: null,
              orderby: x => x.OrderByDescending(x => x.FirstName)
              );
            List<CompanyManagerVM> companyManagers = new List<CompanyManagerVM>();
            foreach (var personel in companyPersonels)
            {
                if (await IsCompanyManager(personel.UserName))
                {
                    companyManagers.Add(personel);
                }
            }

            return companyManagers;
        }

        public async Task<List<DepartmentVM>> GetDepartments()
        {
            var departments = await _departmentRepository.GetFilteredList(
              select: x => new DepartmentVM()
              {
                  Id = x.Id,
                  Name = x.Name

              },
              where: x => x.StatuId == Status.Active.GetHashCode(),
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
              where: x => x.StatuId == Status.Active.GetHashCode(),
              orderby: x => x.OrderByDescending(x => x.CreatedDate),
              include: x => x.Include(x => x.Department).Include(x => x.Title)
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

        public async Task<bool> IsCompanyManager(string userName)
        {
            AppUser user = await _userManager.FindByNameAsync(userName);

            foreach (var roles in await _userManager.GetRolesAsync(user))
            {
                if (roles == "CompanyManager")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
