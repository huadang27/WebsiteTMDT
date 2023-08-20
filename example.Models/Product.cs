using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace example.Models
{
    public class Product
    {
        [Key] public int Id { get; set; }
        [Required] public string Title { get; set; }
        public string Description { get; set; }
        [Required] public string ISBN { get; set; }
        [Required] public string Author { get; set; }

        [Display(Name = "Publish Date")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        [Range(1, 1000)]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 1 - 50")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }


        [ValidateNever]
        public List<ProductImage> ProductImages { get; set; }

        public int SellerId { get; set; }
        [ForeignKey("SellerId")]
        [ValidateNever]
        public Seller Seller { get; set; }

    }
}
