using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace example.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public int Sales { get; set; }
        public double Ratings { get; set; }
        public string ContactInformation { get; set; }
        public string ShippingPolicy { get; set; }
        public string ReturnPolicy { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [ValidateNever]
        public List<Product> Products { get; set; }

        [ValidateNever]
        public List<ProductReview> Reviews { get; set; }
    }

}
