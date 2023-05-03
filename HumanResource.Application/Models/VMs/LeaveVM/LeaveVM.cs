using HumanResource.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.VMs.LeaveVM
{
    public class LeaveVM
    {
        public int Id { get; set; }

        [Display(Name = "Leave Created Date")]
        public string CreatedDate { get; set; }

        [Display(Name = "Leave Start Date")]
        public string StartDate { get; set; }

        [Display(Name = "Leave End Date")]
        public string EndDate { get; set; }

        [Display(Name = "Leave Return Date")]
        public string ReturnDate { get; set; }

        [Display(Name = "Leave Period")]
        public int LeavePeriod { get; set; }
        [Display(Name = "Leave Type")]
        public string LeaveType { get; set; }

    }
}
