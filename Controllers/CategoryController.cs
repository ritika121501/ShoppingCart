using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ShoppingCart.Data;
using ShoppingCart.Models;
using ShoppingCart.NewFolder1;

namespace ShoppingCart.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ShoppingCartContext _context;
        private readonly IToastNotification _toastNotification;


        public CategoryController(ShoppingCartContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
            _toastNotification = toastNotification;
        }

        //public CategoryController(ILogger<HomeController> logger)
        //{
        //_logger = logger;

        //}
        [HttpGet]
        public IActionResult Index()
        {

            var data = _context.Category.ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync(Category category)
        {
            if (category.Name != null && category.Name.ToLower().Contains(ConstantValues.TestData.ToLower()))
            {
                ModelState.AddModelError("Name", "Test is not a valid input");
            }
            if (ModelState.IsValid)
            {
                _context.Category.Add(category);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Submitted Successfully");

                //TempData["Alert Message"] = "Submitted successfully";
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            //LINQ
            var category = _context.Category.Find(id);
            //Lambda expression
            var category1 = _context.Category.FirstOrDefault(x => x.CategoryId == 4);
            //Examples of Linq
            var category2 = _context.Category.Where(category => category.Name.Contains("TEST")).ToList();

            return View(category);

        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category.Name != null && category.Name.ToLower().Contains(ConstantValues.TestData.ToLower()))
            {
                ModelState.AddModelError("Name", "Test is not a valid input");
            }
            if (ModelState.IsValid)
            {
                _context.Category.Add(category);
                _context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Submitted Successfully");

                TempData["Alert Message"] = "Submitted successfully";
                return RedirectToAction("Index");

            }
            return View();
        }


        [HttpPatch]
        public IActionResult Update(Category category)
        {
            if (category.Name != null && category.Name.ToLower().Contains(ConstantValues.TestData.ToLower()))
            {
                ModelState.AddModelError("Name", "Test is not a valid input");
            }
            if (ModelState.IsValid)
            {
                _context.Category.Update(category);
                _context.SaveChanges();
                // toastNotification.AddSuccessToastMessage("Submitted Successfully");

                TempData["Alert Message"] = "Submitted successfully";
                return RedirectToAction("Index");

            }
            return View();
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var category = _context.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id, string name)
        {

            var data = _context.Category.Where(i => (i.CategoryId == id && i.Name == name)).FirstOrDefault();

            if (data != null)
            {
                _context.Category.Remove(data);

                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Category Deleted Successfully");
                TempData["AlertMessage"] = "Category Deleted Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }






    }
}





