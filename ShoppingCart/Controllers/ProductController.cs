using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCart.Data;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using ShoppingCart.Utility;
using ShoppingCart.ViewModels;

namespace ShoppingCart.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _repo;
        private readonly IRepository<Category> _cateRepo;
        public ProductController(IRepository<Product> repo, IRepository<Category> cateRepo)
        {
            _repo = repo;
            _cateRepo = cateRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _repo.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult UpsertProduct(int? id)
        {
            //SelectListItem
            IEnumerable<SelectListItem> categoryList = _cateRepo.GetAll().Select(u=> new SelectListItem
            { 
                Text = u.Name,
                Value = u.CategoryId.ToString()
            });
            //ViewBag it is dynamic type
            //ViewBag.CategoryList = categoryList;

            //ViewData is a type datadictionary
            //With both viewbag and viewdata after it is read for the first time the data will not populate again
            //ViewData["CategoryList"] = categoryList;
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategoryList = categoryList
            };
            if(id==null || id == 0)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _repo.GetById(id.Value);
                return View(productVM);
            }
        }

        [HttpPost]
        public IActionResult UpsertProduct(Product product)
        {
            if (product.Title != null && product.Title.ToLower().Contains(ConstantValues.TestData.ToLower()))
            {
                ModelState.AddModelError("Title", "Test is not a valid input");
            }

            if (string.IsNullOrWhiteSpace(product.Title))
            {
                ModelState.AddModelError("Title", "Title yet to be decided");

            }
            if (string.IsNullOrWhiteSpace(product.Author))
            {
                ModelState.AddModelError("Author", "Author yet to be decided");

            }
            if (string.IsNullOrWhiteSpace(product.ISBN))
            {
                ModelState.AddModelError("ISBN", "ISBN yet to be decided");

            }
            if (!(product.ListPrice > 0))
            {
                ModelState.AddModelError("ListPrice", "ListPrice yet to be decided");

            }
            if (ModelState.IsValid)
            {
                _repo.Insert(product);
                return RedirectToAction("Index");
            }
            IEnumerable<SelectListItem> categoryList = _cateRepo.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.CategoryId.ToString()
            });
            ViewData["CategoryList"] = categoryList;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (product.Title != null && product.Title.ToLower().Contains(ConstantValues.TestData.ToLower()))
            {
                ModelState.AddModelError("Title", "Test is not a valid input");
            }
            if (ModelState.IsValid)
            {
                _repo.Update(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(Product product)
        {
            _repo.Delete(product);
            return RedirectToAction("Index");
        }
    }
}
