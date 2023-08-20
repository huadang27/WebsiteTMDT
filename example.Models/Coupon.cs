namespace example.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        // mã giảm giá
        public string Code { get; set; }

        // Mô tả ngắn gọn về mã giảm giá và ưu đãi.
        public string Description { get; set; }
        //Số tiền giảm giá hoặc tỷ lệ phần trăm giảm giá áp dụng cho đơn hàng.
        public float DiscountAmount { get; set; }

        // Số tiền tối thiểu mà người dùng cần tiêu để mã giảm giá có hiệu lực
        public float MinimumSpend { get; set; }

        //thời gian bắt đầu 
        public DateTime StartDate { get; set; }
        // thời gian kết thúc
        public DateTime EndDate { get; set; }
        //Số lần tối đa mà mỗi mã giảm giá có thể được sử dụng.
        public int MaxUseTimes { get; set; }
        // Số lần mã giảm giá đã được sử dụng
        public int UsedTimes { get; set; }
        //Một thuộc tính boolean cho biết liệu mã giảm giá có áp dụng cho tất cả các sản phẩm hay không.
        public bool ApplyForAllProducts { get; set; }

        //Một thuộc tính boolean cho biết liệu mã giảm giá có đang hoạt động hay không
        public bool IsActive { get; set; }
    }
}
