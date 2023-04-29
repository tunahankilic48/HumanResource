using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>, IBaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; } // ToDo: Güncellenecek
        public int DepartmentId { get; set; }
        public DateTime RecruitmentDate { get; set; }
        public DateTime BirthDate { get; set; }
        public int BloodTypeId { get; set; }
        public Guid ManagerId { get; set; }

        //Navigation Properties
        public Department Department { get; set; }
        public BloodType BloodType { get; set; }
        public AppUser Manager { get; set; }
        // ToDo: Addres eklendikten sonra navigasyonu eklenecek 



    }
}
