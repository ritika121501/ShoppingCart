using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
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
        private readonly IToastNotification _toastNotification;
        public CartVM CartVm { get; set; }
        public InvoiceController(IRepository<Cart> repo, IToastNotification toastNotification)
        {
            _repo= repo;
            _toastNotification = toastNotification;
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

				//c.Product.ListPrice = (int)GetPriceBasedOnQuantity(c);
				//CartVm.OrderTotal += c.Product.ListPrice * c.Count;

                int priceBasedonQuantity = (int)GetPriceBasedOnQuantity(c);
                CartVm.OrderTotal += priceBasedonQuantity;
            }
			

			return View(CartVm);

		}

        [HttpGet]
        public IActionResult UpdateProductQuantity(int Id, string op)

        {
            Cart cart = new Cart();

            cart = _repo.GetById(Id);
            //cart = _repo.Get(x=> x.ProductId == productId && x.ApplicationUserId == applicationUserId);
            //x.ProductId == productId && x.ApplicationUserId == applicationUserId

            if (cart == null)
            {
                return NotFound();
            }
            //foreach(var item in cart)
            //{ 
            //if (cart.id==item.id && cart.ProductId == productId && cart.ApplicationUserId == applicationUserId)
            if (op == "delete")
            {
                _repo.Delete(cart);
                _toastNotification.AddSuccessToastMessage("Item Deleted Successfully");
            }

            else
            {
                if (op == "minus")
                {
                    if (cart.Count > 1)
                    {
                        cart.Count -= 1;
                        _repo.Update(cart);
                    }

                    else
                        _repo.Delete(cart);
                }
                else if (op == "plus")
                {
                    cart.Count += 1;
                    _repo.Update(cart);
                }
                //_toastNotification.AddSuccessToastMessage("Item count Updated Successfully");
            }
            //_toastNotification.AddSuccessToastMessage("Items Updated Successfully");
            return RedirectToAction("Index");



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