namespace example.Models.ViewModel
{
    public class ShoppingCartVM
    {

        // vô số giỏ hàng 
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }

        // tiêu đề dơn hàng

        public OrderHeader OrderHeader { get; set; }
        public string CouponCode { get; set; }








    }
}
