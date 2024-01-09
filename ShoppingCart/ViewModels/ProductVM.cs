using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCart.Models;

namespace ShoppingCart.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        
        public IEnumerable<SelectListItem>CategoryList { get; set; }
    }
}
