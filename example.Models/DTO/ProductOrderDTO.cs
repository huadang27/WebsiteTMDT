using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example.Models.DTO
{
	public class ProductOrderDTO
	{
		public ProductDTO Product { get; set; }
		public int TotalOrderedQuantity { get; set; }
	}
}
