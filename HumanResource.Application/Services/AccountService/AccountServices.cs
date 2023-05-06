using AutoMapper;
using HumanResource.Application.Models.DTOs.AccountDTO;
using HumanResource.Application.Models.VMs.PersonelVM;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Repositries;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Image = SixLabors.ImageSharp.Image;

namespace HumanResource.Application.Services.AccountServices
{
    public class AccountServices : IAccountServices
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountServices(IAppUserRepository appUserRepository, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper, IDistrictRepository districtRepository, ICityRepository cityRepository, IDepartmentRepository departmentRepository)
        {
            _appUserRepository = appUserRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _districtRepository = districtRepository;
            _cityRepository = cityRepository;
            _departmentRepository = departmentRepository;
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
                UserName = x.UserName,
                Email = x.Email,
                RecruitmentDate = x.RecruitmentDate,
                BirthDate = x.BirthDate,
                ManagerName = x.Manager.FirstName + " " + x.Manager.LastName,
                DepartmentName = x.Department.Name,
                BloodTypeId = x.BloodTypeId,
                CityId = x.Address.District.CityId,
                DistrictId = x.Address.DistrictId,
                AddressDescription = x.Address.Description,
                ImagePath = x.ImagePath,
                FullName = x.FirstName + " " + x.LastName
            },
            where: x => x.UserName == userName,
            orderby: null,
            include: x => x.Include(x => x.Manager).Include(x => x.Department).Include(x => x.Address).Include(x => x.Address.District)
            );


            return result;
        }

        public async Task<SignInResult> Login(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.UserNameOrEmail);
            if (user != null)
            {
                return await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);
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
            RegisterVM register = new RegisterVM();
            if (result.Succeeded)
            {

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                register.Email = user.Email;
                register.Token = token;
                register.Result = result;
                //await _signInManager.SignInAsync(user, isPersistent: false);
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
    }
}
