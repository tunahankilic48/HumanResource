using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string TelNo { get; set; }
        public int addressId { get; set; }
        public string departman { get; set; }
        public DateTime WorkStartDate { get; set; }
        public string adminFirstName { get; set; }
        public string adminLastName { get; set; }

    }
}
