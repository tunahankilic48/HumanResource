using HumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HumanResource.Application.Models.VMs.LeaveVM
{
    internal class LeaveVM
    {
        public int Id { get; set; }

        [Display(Name = "İzin Oluşturulma Tarihi tarihi")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "İzin Başlangıç tarihi")]
        public DateTime StartDate { get; set; }

        [Display(Name = "İzin Bitiş tarihi")]
        public DateTime EndDate { get; set; }

        [Display(Name = "İzinden Dönüş tarihi")]
        public DateTime ReturnDate { get; set; }
        public int LeavePeriod { get; set; }
        public int LeaveTypeId { get; set; }

        //public Statu Statu { get; set; }
        //data anno--> display names turkce olarak olus tar. vs.
    }
}
