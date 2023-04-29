using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Application.Models.DTOs.AppUserDTO
{
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        //Sorulacak : Personel girişi email mi olacak username mi olacak ?
        //ToDo : Data Anotation eklenecek , kısıtlamalar eklenebilir
    }
}
