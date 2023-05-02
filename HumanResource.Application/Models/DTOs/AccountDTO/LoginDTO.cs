using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.DTOs.AccountDTO
{
    public class LoginDTO
    {
        [MinLength(6, ErrorMessage = "Kullanıcı Adı 6 karakterden az giremezsiniz"), Required(ErrorMessage ="Bu alanı girmek zorunludur"), Display(Name = "Kullanıcı Adı")]
        public string UserNameOrEmail { get; set; }
        [MinLength(6, ErrorMessage = "Şifreniz 6 karakterden az giremezsiniz"), Required(ErrorMessage = "Bu alanı girmek zorunludur"), Display(Name = "Şifre"), DataType(DataType.Password)]
        public string Password { get; set; }
       
        
        
    }
}
