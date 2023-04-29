using HumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Application.Models.DTOs.AppUserDTO
{
    public class RegisterDTO
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        //public Statu MSyProperty { get; set; }
        public DateTime CreateDate => DateTime.Now;

        //ToDo : Data Anotation eklenecek, statu eklenebilir
    }
}
