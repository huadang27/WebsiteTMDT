namespace example.Models.ViewModel
{
    public class ProductReviewVM
    {
        // vô số giỏ hàng 
        public IEnumerable<ProductReview> ProductReviewList { get; set; }

        // tiêu đề dơn hàng

        public ShoppingCart ShoppingCart { get; set; }
        public ProductReview ProductReview { get; set; }
        // New property
        public int ProductId { get; set; }


        public string ApplicationUserId { get; set; }

		public int TotalOrderedQuantity { get; set; }


	}
}
