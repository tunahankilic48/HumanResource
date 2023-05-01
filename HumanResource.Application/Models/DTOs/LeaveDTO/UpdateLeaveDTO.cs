using HumanResource.Application.Extensions;
using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.DTOs.LeaveDTO
{
    public class UpdateLeaveDTO
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Başlangıç Tarihi Boş Geçilemez.")]
        [Display(Name ="İzin Başlangıç Tarihi")]
        [DataType(DataType.Date)]
        [StartDate]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş Tarihi Boş Geçilemez.")]
        [Display(Name = "İzin Bitiş Tarihi")]
        [DataType(DataType.Date)]
        [StartDate]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "İşe dönüş Tarihi Boş Geçilemez.")]
        [Display(Name = "İşe Dönüş Tarihi")]
        [DataType(DataType.Date)]
        [StartDate]
        public DateTime ReturnDate { get; set; }

        [Required(ErrorMessage = "İzin Türü Boş Geçilemez.")]
        public int LeaveTypeId { get; set; }

        //public Statu Statu { get; set; }

    }
}
