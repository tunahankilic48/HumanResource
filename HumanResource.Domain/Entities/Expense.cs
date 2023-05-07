using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain.Entities
{
    public class Expense : IBaseEntity
    {
        public int? StatuId { get ; set ; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Statu? Statu { get; set; }
        /*************************************************************************/
        public int Id { get; set; }
        public int UserId { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        /*************************************************************************/
        //Navigation

        public AppUser User { get; set; }
        public List<Department> Departments { get; set; } //çoka çok ilişki olabilir
    }
}
