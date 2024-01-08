using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ShoppingCart.Data;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using ShoppingCart.Utility;
using ShoppingCart.ViewModels;

namespace ShoppingCart.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> _repo;
        private readonly IToastNotification _toastNotification;
	
		public CategoryController(IRepository<Category> repo, IToastNotification toastNotification)
        {
            _repo = repo;
            _toastNotification = toastNotification;
        }

        [HttpGet]
		public IActionResult Index()
		{
			var data = _repo.GetAll();
			return View(data);
		}

        [HttpGet]
        public IActionResult UpsertCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var category = _repo.GetById(id.Value);
                if (category == null)
                {
                    return NotFound();
                }
                return View(category);

			}

		}

		[HttpPost]
			public IActionResult UpsertCategory(Category category)
        {
            if (category.Name != null && category.Name.ToLower().Contains(ConstantValues.TestData.ToLower()))
            {
                ModelState.AddModelError("Name", "Test is not a valid input");
            }
            if (ModelState.IsValid)
            {
                _repo.Insert(category);
                _toastNotification.AddSuccessToastMessage("Category Added Successfully");
                return RedirectToAction("Index");
            }
            return View();
        }

      
        public IActionResult Delete(Category category)
        { 
            _repo.Delete(category);
            return RedirectToAction("Index");
        }
    }
}
