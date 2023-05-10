using AutoMapper;
using HumanResource.Application.Models.DTOs.AccountDTO;
using HumanResource.Application.Models.DTOs.CompanyManagerDTO;
using HumanResource.Application.Models.VMs.PersonelVM;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Repositries;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Image = SixLabors.ImageSharp.Image;

namespace HumanResource.Application.Services.AccountServices
{
    public class AccountServices : IAccountServices
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountServices(IAppUserRepository appUserRepository, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _appUserRepository = appUserRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                return result;
            }
            return IdentityResult.Failed();


        }

        public async Task<UpdateProfileDTO> GetByUserName(string userName)
        {
            UpdateProfileDTO result = await _appUserRepository.GetFilteredFirstOrDefault(
            select: x => new UpdateProfileDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                NumberOfEmployee = x.Company.NumberOfEmployee,
                TaxNumber = x.Company.TaxNumber,
                TaxOfficeName = x.Company.TaxOfficeName,
                CompanyName = x.Company.CompanyName,
                CityId = x.Address.District.CityId,
                DistrictId = x.Address.DistrictId,
                AddressDescription = x.Address.Description,
                BloodTypeId = x.BloodTypeId,
                DepartmentName = x.Department.Name,
                BirthDate = x.BirthDate,
                RecruitmentDate = x.RecruitmentDate,
                ManagerName = x.Manager.FirstName + " " + x.Manager.LastName,
                ImagePath = x.ImagePath,
                FullName = x.FirstName + " " + x.LastName,
                TitleName = x.Title.Name
            },
            where: x => x.UserName == userName,
            orderby: null,
            include: x => x.Include(x => x.Manager).Include(x => x.Department).Include(x => x.Address).Include(x => x.Address.District).Include(x=>x.Title)
            );


            return result;
        }

        public async Task<SignInResult> Login(LoginDTO model)
        {
            var userEmail = await _userManager.FindByEmailAsync(model.UserNameOrEmail);
            var userName = await _userManager.FindByNameAsync(model.UserNameOrEmail);
            if(userEmail == null && userName == null)
            {
                return SignInResult.Failed;
            }

            if (userEmail != null)
            {
                return await _signInManager.PasswordSignInAsync(userEmail.UserName, model.Password, false, false);
            }
            return await _signInManager.PasswordSignInAsync(model.UserNameOrEmail, model.Password, false, false);
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<RegisterVM> Register(RegisterDTO model)
        {
            AppUser user = _mapper.Map<AppUser>(model);

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, "Employee");
            RegisterVM register = new RegisterVM();
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                register.Email = user.Email;
                register.Token = token;
                register.Result = result;
            }
            else
            {

                register.Result = result;
            }
            return register;
        }

        public async Task UpdateUser(UpdateProfileDTO model)
        {
            AppUser user = await _appUserRepository.GetDefault(x => x.Id == model.Id);

            if (model.Password != null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            }

            if (model.Email != null)
            {
                AppUser isUserMailExists = await _userManager.FindByEmailAsync(model.Email);
                if (isUserMailExists == null)
                    await _userManager.SetEmailAsync(user, model.Email);
            }
            if (model.UserName != null)
            {
                AppUser isUserNameExists = await _userManager.FindByNameAsync(model.UserName);
                if (isUserNameExists == null)
                    await _userManager.SetUserNameAsync(user, model.UserName);
            }
            if (model.Image != null)
            {
                using var image = Image.Load(model.Image.OpenReadStream());

                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/media/images/{guid}.jpg");

                user.ImagePath = $"/media/images/{guid}.jpg";
            }
            else
                user.ImagePath = model.ImagePath;
            user.FirstName = model.FirstName; 
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.BirthDate = model.BirthDate;
            user.BloodTypeId = model.BloodTypeId;

            if (model.DistrictId != 0 && model.CityId != 0)
            {
                if (user.Address == null)
                {
                    user.Address = new Address()
                    {
                        CreatedDate = DateTime.Now,
                        Description = model.AddressDescription,
                        DistrictId = model.DistrictId,
                    };

                }
                else
                {
                    user.Address.ModifiedDate = DateTime.Now;
                    user.Address.DistrictId = model.DistrictId;
                    user.Address.Description = model.AddressDescription;
                }
            }

            await _userManager.UpdateAsync(user);

        }

        public async Task<IList<string>> GetUserRole(string userName)
        {
            AppUser user = await _userManager.FindByNameAsync(userName);
            var result = await _userManager.GetRolesAsync(user);
            return result;
        }

        public async Task<bool> IsCompanyManager(string userName)
        {
            var roles = await GetUserRole(userName);

            foreach (var role in roles)
            {
                if (role == "CompanyManager")
                    return true;
            }
            return false;
        }
    }
}
