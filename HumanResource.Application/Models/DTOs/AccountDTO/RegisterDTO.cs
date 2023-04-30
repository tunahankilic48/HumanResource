using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HumanResource.Application.Models.DTOs.AccountDTO
{
    public class RegisterDTO
    {
        [StringLength(20, ErrorMessage = "Kullanıcı Adını 20 karakterden fazla giremezsiniz"), Required(ErrorMessage = "Bu alanı girmek zorunludur"), Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [StringLength(30, ErrorMessage = "Adınız 30 karakterden fazla giremezsiniz"), Required(ErrorMessage = "Bu alanı girmek zorunludur"), Display(Name = "Adı")]
        public string FirstName { get; set; }
        [StringLength(30, ErrorMessage = "Soyadınız 30 karakterden fazla giremezsiniz"), Required(ErrorMessage = "Bu alanı girmek zorunludur"), Display(Name = "Soyadı")]
        public string LastName { get; set; }
        [StringLength(13, ErrorMessage = "Şifreniz 13 karakterden fazla giremezsiniz"), Required(ErrorMessage = "Bu alanı girmek zorunludur"), Display(Name = "Şifre")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="Şifreniz uyuşmuyor")]
        public string ConfirmPassword { get; set; }
        [ Required(ErrorMessage = "Bu alanı girmek zorunludur"), Display(Name = "E-Posta")]
        public string Email { get; set; }
        //public Statu MSyProperty { get; set; }
        public DateTime CreateDate => DateTime.Now;

        //ToDo : statu eklenebilir
    }
}
