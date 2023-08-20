using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace example.Models
{
    public class ProductReview
    {
        public int Id { get; set; }

        [Required]
        // xep hang
        public int Rating { get; set; }
        [Required]
        // bình luận
        public string Comment { get; set; }
        [Required]
        // ngày tao
        public DateTime DateCreated { get; set; }


        // Navigation properties
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }


        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

	




	}
}
