using HumanResource.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HumanResource.Application.Models.DTOs.AccountDTO
{
    public class RegisterDTO
    {
        [MinLength(6, ErrorMessage = "Kullanıcı Adınız 6 karakterden az giremezsiniz"), Required(ErrorMessage = "Bu alanı girmek zorunludur"), Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [StringLength(30, ErrorMessage = "Adınız 30 karakterden fazla giremezsiniz"), Required(ErrorMessage = "Bu alanı girmek zorunludur"), Display(Name = "Ad")]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "Soyadınız 50 karakterden fazla giremezsiniz"), Required(ErrorMessage = "Bu alanı girmek zorunludur"), Display(Name = "Soyad")]
        public string LastName { get; set; }
        [MinLength(6, ErrorMessage = "Şifreniz 6 karakterden az giremezsiniz"), Required(ErrorMessage = "Bu alanı girmek zorunludur"), Display(Name = "Şifre"), DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="Şifreniz uyuşmuyor"), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [ Required(ErrorMessage = "Bu alanı girmek zorunludur"), Display(Name = "E-Posta"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        //public Statu MSyProperty { get; set; }
        public DateTime CreatedDate => DateTime.Now;
       // public AppUser User { get; set; }

        //ToDo : statu eklenebilir
    }
}
