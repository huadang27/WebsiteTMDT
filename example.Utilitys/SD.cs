namespace example.Utility
{
    public static class SD
    {

        // Vai trò người dùng
        public const string Role_Customer = "Customer"; // Vai trò "Khách hàng"
        public const string Role_Company = "Company"; // Vai trò "Công ty"
        public const string Role_Admin = "Admin"; // Vai trò "Quản trị viên"
        public const string Role_Employee = "Employee"; // Vai trò "Nhân viên"
        public const string Role_Seller = "Seller"; // Vai trò "User bán hàng"


        // Trạng thái đơn hàng
        public const string StatusPending = "Pending"; // Đơn hàng "Đang chờ xử lý"
        public const string StatusApproved = "Approved"; // Đơn hàng "Đã được chấp nhận""" 
        public const string StatusInProcess = "Processing"; // Đơn hàng "Đang xử lý"
        public const string StatusShipped = "Shipped"; // Đơn hàng "Đã gửi hàng" "Shipped"
        public const string StatusCancelled = "Cancelled"; // Đơn hàng "Đã hủy"
        public const string StatusRefunded = "Refunded"; // Đơn hàng "Đã hoàn tiền"

        // Trạng thái thanh toán
        public const string PaymentStatusPending = "Pending"; // Thanh toán "Chờ xử lý"
        public const string PaymentStatusApproved = "Approved"; // Thanh toán "Đã chấp nhận"
        public const string PaymentsStatusDelayedPayment = "ApprovedForDelayedPayment"; // Thanh toán "Được chấp nhận cho thanh toán trễ hẹn"
        public const string PaymentStatusRejected = "Rejected"; // Thanh toán "Bị từ chối"


        public const string SessionCart = "SessionShoppingCart";
    }


}
