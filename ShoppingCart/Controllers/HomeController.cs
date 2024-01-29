using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using System.Diagnostics;
using Microsoft.AspNet.Identity;

namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Product> _repo;
        readonly IRepository<Cart> _cartRepository;

        public HomeController(ILogger<HomeController> logger, IRepository<Product> repo, IRepository<Cart> cartRepo)
        {
            _logger = logger;
            _repo = repo;
            _cartRepository = cartRepo;
        }

        public IActionResult Index()
        {
            var g = User.Identity.GetUserId();

            IEnumerable<Product> products = _repo.GetAll(includeProperties: "Category");
            return View(products);
        }

        [HttpGet]
        public IActionResult Details(int productId)
        {
            // Product product = _repo.Get(u=>u.Id==productId);            		
			return View(GetCartByProductId(productId));
        }

        [HttpPost]
		public IActionResult Details(Cart cartTmp)
		{
            // Product product = _repo.Get(u=>u.Id==productId);
            if (cartTmp != null)
            {
                Cart? cart = GetCartByProductId(cartTmp.ProductId);
                if(cart != null)
                {
                    if(cart.Count > 0)
                    {
						cart.Count = cartTmp.Count;
						_cartRepository.Update(cart);
					}
                    else
                    {
						cart = new()
						{
							Count = cartTmp.Count,
							ProductId = cartTmp.ProductId,
							ApplicationUserId = User.Identity.GetUserId()
						};
						_cartRepository.Insert(cart);
					}                    
                }                
            }

			return RedirectToAction("Index");
		}

		public IActionResult Privacy()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        Cart? GetCartByProductId(int productId)
        {
			Cart? cart = null;
			var carts = _cartRepository.GetAll(ct => ct.ApplicationUserId == User.Identity.GetUserId());
			if (carts != null)
			{
				Product product = _repo.GetById(productId);
				cart = carts.FirstOrDefault(ct => ct.ProductId == product.Id);
				cart ??= new()
				{
					Product = product
				};
			}
            return cart;
		}
    }
}