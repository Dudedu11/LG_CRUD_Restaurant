using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LG_CRUD_Restaurant.Models
{
	public class Transaction
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public int FoodId { get; set; }
	}
}
