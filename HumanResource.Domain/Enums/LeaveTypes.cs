using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HumanResource.Domain.Enums
{
    public enum LeaveTypes
    {
        [Display(Name = "Annual Leave")]
        AnnualLeave = 1,
        [Display(Name = "Maternity Leave")]
        MaternityLeave,
        [Display(Name = "Paternity Leave")]
        PaternityLeave,
        [Display(Name = "Pregnancy Control Leave")]
        PregnancyControlLeave,
        [Display(Name = "Death Warrant")]
        DeathWarrant,
        [Display(Name = "New Job Search Permit")]
        NewJobSearchPermit,
        [Display(Name = "Marriage Permission")]
        MarriagePermission,
        [Display(Name = "Paid Leave")]
        PaidLeave
    }
}
