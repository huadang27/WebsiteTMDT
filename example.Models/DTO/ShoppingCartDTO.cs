using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example.Models.DTO
{
    public class ShoppingCartDTO
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }

        public double QuantityProduct { get; set; }


        // Lấy thông tin product


    }

}
