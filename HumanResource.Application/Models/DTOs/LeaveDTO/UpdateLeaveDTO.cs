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
    internal class UpdateLeaveDTO
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Başlangıç Tarihi giriniz")]
        [Display(Name ="İzin Başlangıç tarihi")]
        [DataType(DataType.Date)]

        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş Tarihi giriniz")]
        [Display(Name = "İzin Bitiş tarihi")]
        [DataType(DataType.Date)]

        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "İşe dönüş Tarihinizi giriniz")]
        [Display(Name = "İzinden Dönüş tarihi")]
        [DataType(DataType.Date)]

        public DateTime ReturnDate { get; set; }

        [Required(ErrorMessage = "LeaveType tipinde olmalı")]
        public int LeaveTypeId { get; set; }

        //public Statu Statu { get; set; }
        //Data Anno
    }
}
