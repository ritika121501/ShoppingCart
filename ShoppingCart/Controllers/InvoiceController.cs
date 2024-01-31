using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using ShoppingCart.ViewModels;
using System.Security.Claims;

namespace ShoppingCart.Controllers
{
	public class InvoiceController : Controller
	{
        private readonly IRepository<Cart> _repo;
        //private readonly IToastNotification _toastNotification;
		public CartVM CartVm { get; set; }
        public InvoiceController(IRepository<Cart> repo)
        {
            _repo= repo;
        }


		public IActionResult Index()
		{
			var claimIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			CartVm = new()
			{
				Carts = _repo.GetAllWithFilter(y => y.ApplicationUserId == userId, includeProperties: "Product").ToList()
			};
			foreach (var c in CartVm.Carts)
			{
				int PriceBasedOnQuantity = (int)GetPriceBasedOnQuantity(c);
				CartVm.OrderTotal += PriceBasedOnQuantity;
			}


			return View(CartVm);

		}

		public IActionResult GetInvoice()
		{
			return View();
		}

		private double GetPriceBasedOnQuantity(Cart cart)
        {
			var price = cart.Product.ListPrice * cart.Count;
            
			return price;
        }
	}
}