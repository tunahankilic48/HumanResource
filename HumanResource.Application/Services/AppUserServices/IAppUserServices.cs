using HumanResource.Application.Models.DTOs.AppUserDTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Application.Services.AppUserServices
{
    public interface IAppUserServices
    {
        Task<IdentityResult> Register(RegisterDTO model);
        Task<SignInResult> Login(LoginDTO model);
        Task<UpdateProfileDTO> GetByUserName(string userName);
        Task UpdateUser(UpdateProfileDTO model);
        Task LogOut();
        //ToDo : personelin izin taleplerini listeleyecek metod 
        //ToDo : personelin avans taleplerini listeleyecek metod 
        //ToDo : personelin genel bilgilerini görmek için bir metod eklenebilir. (VM'de kullanabilmek için)
    }
}
