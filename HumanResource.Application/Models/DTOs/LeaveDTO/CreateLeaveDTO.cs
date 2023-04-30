using HumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Application.Models.DTOs.LeaveDTO
{
    internal class CreateLeaveDTO
    {
        public Guid UserId { get; set; }
        public DateTime CreatedDate => DateTime.Now;

        [Required(ErrorMessage = "Başlangıç Tarihi giriniz")]
        [Display(Name = "İzin Başlangıç tarihi")]
        [DataType(DataType.Date)]

        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş Tarihi giriniz")]
        [Display(Name = "İzin Bitiş tarihi")]
        [DataType(DataType.Date)]
        //ToDo: Tarih aralığı için anno bakılacak

        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "İşe dönüş Tarihinizi giriniz")]
        [Display(Name = "İzinden Dönüş tarihi")]
        [DataType(DataType.Date)]

        public DateTime ReturnDate { get; set; }

        [Required(ErrorMessage = "İzin sebebinizi giriniz")]
        public int LeaveTypeId { get; set; }

        //public Statu Statu { get; set; }

        //Data Anno startdate için vs.
    }
}
