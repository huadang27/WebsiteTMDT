using example.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace example.Models.ViewModel
{
    public class ProductVM
    {
        public Product Product { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? CategoryList { get; set; }

        [ValidateNever]
        public   IEnumerable<ProductWithTotalCount> ?GetProductsTop10 { get; set; }
    }
}
