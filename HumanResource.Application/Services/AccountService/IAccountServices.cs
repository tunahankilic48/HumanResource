using HumanResource.Application.Models.DTOs.AccountDTO;
using Microsoft.AspNetCore.Identity;

namespace HumanResource.Application.Services.AccountServices
{
    public interface IAccountServices
    {
        Task<IdentityResult> Register(RegisterDTO model);
        Task<SignInResult> Login(LoginDTO model);
        Task<UpdateProfileDTO> GetByUserName(string userName);
        Task UpdateUser(UpdateProfileDTO model);
        Task LogOut();

    }
}
