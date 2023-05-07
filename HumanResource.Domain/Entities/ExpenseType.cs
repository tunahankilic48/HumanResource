using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain.Entities
{
	public class ExpenseType
	{
		public int Id { get; set; }
		public string Name { get; set; }
		
		public int ExpenseTypeEnumId { get; set; }

		//Navigation Property
		public List<Expense> Expenses { get; set; }
	}
}
