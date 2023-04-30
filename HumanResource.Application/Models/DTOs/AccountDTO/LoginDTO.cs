using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.DTOs.AccountDTO
{
    public class LoginDTO
    {
        [StringLength(20, ErrorMessage ="20 karakterden fazla giremezsiniz"),Required(ErrorMessage ="Bu alanı girmek zorunludur"), Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [StringLength(13, ErrorMessage = "13 karakterden fazla giremezsiniz"), Required(ErrorMessage = "Bu alanı girmek zorunludur"),Display(Name ="Şifre")]
        public string Password { get; set; }
        //Sorulacak : Personel girişi email mi olacak username mi olacak ?
        
    }
}
