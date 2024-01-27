using ShoppingCart.Models;

namespace ShoppingCart.ViewModels
{
    public class CartVM
    {
        public List<Cart> Carts { get; set; }
        public double OrderTotal { get; set; }
    }
}
