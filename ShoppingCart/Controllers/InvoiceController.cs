using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ShoppingCart.Models;
using ShoppingCart.Repository;

namespace ShoppingCart.Controllers
{
	public class InvoiceController : Controller
	{
		private readonly IRepository<Invoice> _repo;
		private readonly IToastNotification _toastNotification;
		public InvoiceController(IRepository<Invoice> repo, IToastNotification toastNotification)
		{
			_repo = repo;
			_toastNotification = toastNotification;
		}
		public IActionResult Index()
		{
			var data = _repo.GetAll();
			return View(data);
			
		}

		public IActionResult GetInvoice()
		{
			return View();
		}
	}
}
