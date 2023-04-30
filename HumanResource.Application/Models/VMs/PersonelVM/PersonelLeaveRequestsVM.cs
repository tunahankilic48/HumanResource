using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.VMs.PersonelVM
{
    internal class PersonelLeaveRequestsVM
    {
        [Display(Name ="İzin Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }
        [Display(Name = "İzin Bitiş Tarihi")]
        public DateTime EndDate { get; set; }
        [Display(Name = "GEri Dönüş Tarihi")]
        public DateTime ReturnDate { get; set; }
        [Display(Name ="İzin Sebebi")]
        public string LeaveType { get; set; }
    }
}
