using AutoMapper;
using HumanResource.Application.Models.DTOs.AccountDTO;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Repositries;
using Microsoft.AspNetCore.Identity;

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
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<UpdateProfileDTO> GetByUserName(string userName)
        {
            UpdateProfileDTO result = await _appUserRepository.GetFilteredFirstOrDefault(
            select: x => new UpdateProfileDTO
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email
            },
            where: x => x.UserName == userName);

            return result;
        }

        public async Task<SignInResult> Login(LoginDTO model)
        {
            return await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
        }

        public async Task LogOut()
        {
           await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterDTO model)
        {
            AppUser user = _mapper.Map<AppUser>(model);


            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            return result;
        }

        public async Task UpdateUser(UpdateProfileDTO model)
        {
            AppUser user = await _appUserRepository.GetDefault(x => x.Id == model.Id);

            if (model.Password != null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                await _userManager.UpdateAsync(user);
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
            
            
        }
    }
}
