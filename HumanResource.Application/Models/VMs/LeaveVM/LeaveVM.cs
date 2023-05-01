using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.VMs.LeaveVM
{
    public class LeaveVM
    {
        public int Id { get; set; }

        [Display(Name = "İzin Oluşturulma Tarihi")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "İzin Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }

        [Display(Name = "İzin Bitiş Tarihi")]
        public DateTime EndDate { get; set; }

        [Display(Name = "İşe Dönüş Tarihi")]
        public DateTime ReturnDate { get; set; }
        [Display(Name = "İzin Süresi")]
        public int LeavePeriod { get; set; }
        [Display(Name = "İzin Türü")]
        public string LeaveType { get; set; }

        //public Statu Statu { get; set; }
    }
}
