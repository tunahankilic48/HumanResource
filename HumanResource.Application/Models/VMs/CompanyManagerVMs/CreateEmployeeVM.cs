using Microsoft.AspNetCore.Identity;

namespace HumanResource.Application.Models.VMs.CompanyManagerVMs
{
    public class CreateEmployeeVM
    {
        public IdentityResult Result { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
