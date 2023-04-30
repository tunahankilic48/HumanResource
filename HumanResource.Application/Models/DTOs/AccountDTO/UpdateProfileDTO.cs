using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HumanResource.Application.Models.DTOs.AccountDTO
{
    public class UpdateProfileDTO
    {
        public Guid Id { get; set; }
        [MinLength(6, ErrorMessage = "Kullanıcı Adını 6 karakterden az giremezsiniz"), Required(ErrorMessage = "Bu alanı girmek zorunludur"), Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [MinLength(6, ErrorMessage = "Şifreniz 6 karakterden az giremezsiniz"), Required(ErrorMessage = "Bu alanı girmek zorunludur"), Display(Name = "Şifre"), DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Şifreniz uyuşmuyor"), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Bu alanı girmek zorunludur"), Display(Name = "E-Posta"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime ModifiedDate { get; set; }
        
    }
}
