namespace example.Models.ViewModel
{
    public class OrderVM
    {
        // thông tin đơn hàng

        public OrderHeader OrderHeader { get; set; }


        public IEnumerable<OrderDetail> OrderDetail { get; set; }

        // thông tin chi tiết từng sản phẩm trong đơn hàng


    }
}
