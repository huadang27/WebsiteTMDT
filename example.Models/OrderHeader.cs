using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace example.Models
{
    public class OrderHeader
    {
        // tiêu đề đơn hàng 
        public int Id { get; set; }
        public string? CouponCode { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        // ngay dat hang
        public DateTime OrderDate { get; set; }
        // ngay giao hang
        public DateTime ShoopingDate { get; set; }


        // tong so luong dat hang
        public double OrderTotal { get; set; }

        // trang thai don hang

        public string? OrderStatus { get; set; }

        // trang thai thanh toan
        public string? PaymentStatus { get; set; }
        // số theo dõi đơn hàng 
        public string? TrackingNumber { get; set; }
        // thông tin về nhà cung cấp để theo dõi đơn hàng 
        public string? Carrier { get; set; }

        // nếu người dùng của công ty, sẽ cho họ 30 ngày thanh toán  để thục hiện thanh toán đơn hàng
        // sau khi hàng được đặt
        // Theo dõi ngày thanh toán
        public DateTime PaymentData { get; set; }

        // theo dõi ngày đáo hạn khi hết 30 ngày
        public DateOnly PaymentDuaDate { get; set; }

        // Phiên thanh toán
        public string? SessionId { get; set; }

        // mã thanh toán của đơn hàng 
        public string? PaymentIntentId { get; set; }


        // thông tin địa chỉ giao hàng

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Name { get; set; }


        // lấy thông tin OrderDetails 
        public List<OrderDetail> OrderDetails { get; set; }

      

    }
}
