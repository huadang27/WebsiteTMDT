using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example.Models.DTO
{
    public class ProductWithTotalCount
    {
        public ProductDTO ProductDTO { get; set; }
        public int TotalCount { get; set; }
    }
}
