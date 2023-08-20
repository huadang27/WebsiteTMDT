using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example.Models.DTO
{
    public class OrderHeaderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string OrderStatus { get; set; }
        public double OrderTotal { get; set; }
        // Lấy thông tin product

        public string UserId { get; set; }
     



    }

}
