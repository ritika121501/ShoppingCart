using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCart_Blazor.Data;
using ShoppingCart_Blazor.Models;

namespace ShoppingCart_Blazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ShoppingCartContext _shoppingCartContext;

        public List<Category> CategoryList { get; set; }

        public IndexModel(ShoppingCartContext shoppingCartContext)
        {
            _shoppingCartContext = shoppingCartContext;
        }
        public void OnGet()
        {
            CategoryList = _shoppingCartContext.Category.ToList();
        }
    }
}
