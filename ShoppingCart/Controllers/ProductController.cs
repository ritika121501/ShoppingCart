using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCart.Data;
using NToastNotify;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using ShoppingCart.Utility;
using ShoppingCart.ViewModels;
using System.Diagnostics;
using System.IO;

namespace ShoppingCart.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _repo;
        private readonly IRepository<Category> _cateRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IToastNotification _toastNotification;

        public ProductController(IRepository<Product> repo, IRepository<Category> cateRepo, IWebHostEnvironment webHostEnvironment,
            IToastNotification toastNotification)
        {
            _repo = repo;
            _cateRepo = cateRepo;
            _webHostEnvironment = webHostEnvironment;
            _toastNotification = toastNotification;

        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _repo.GetAll(includeProperties: "Category");
            return View(data);
        }
        [HttpGet]
        public IActionResult UpsertProduct(int? id)
        {
            IEnumerable<SelectListItem> categoryList = _cateRepo.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.CategoryId.ToString()
            });
            
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategoryList = categoryList
            };
            if (id == null || id == 0)
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
        public IActionResult UpsertProduct(ProductVM productVm, IFormFile file)
        {
            if (productVm.Product.Title != null && productVm.Product.Title.ToLower().Contains(ConstantValues.TestData.ToLower()))
            {
                ModelState.AddModelError("Title", "Test is not a valid input");
            }

            if (string.IsNullOrWhiteSpace(productVm.Product.Title))
            {
                ModelState.AddModelError("Title", "Title yet to be decided");

            }
            if (string.IsNullOrWhiteSpace(productVm.Product.Author))
            {
                ModelState.AddModelError("Author", "Author yet to be decided");

            }
            if (string.IsNullOrWhiteSpace(productVm.Product.ISBN))
            {
                ModelState.AddModelError("ISBN", "ISBN yet to be decided");

            }
            if (!(productVm.Product.ListPrice > 0))
            {
                ModelState.AddModelError("ListPrice", "ListPrice yet to be decided");

            }
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images/products/");
                    using (FileStream fs = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fs);
                    }
                    productVm.Product.ImageUrl = @"images/products/" + fileName;
                }
                if (productVm.Product.Id == 0)
                {
                    _repo.Insert(productVm.Product);
                    _toastNotification.AddSuccessToastMessage("Product Added Successfully");
                    return RedirectToAction("Index");
                }
                else
                {
                    _repo.Update(productVm.Product);
                    _toastNotification.AddSuccessToastMessage("Product Updated Successfully");
                    return RedirectToAction("Index");
                }
              
            }

            IEnumerable<SelectListItem> categoryList = _cateRepo.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.CategoryId.ToString()
            });
            ViewData["CategoryList"] = categoryList;
            return View();
        }

		[HttpGet]
		public IActionResult Delete(int Id)
        {
		    Product product=new Product();
            product = _repo.GetById(Id);
			
            string wwwRootPath = _webHostEnvironment.WebRootPath;
		    string filepath;

            if (product.ImageUrl != null)
            {
                filepath = Path.Combine(wwwRootPath, product.ImageUrl);
                System.IO.File.Delete(filepath);    
            }
            _repo.Delete(product);
            _toastNotification.AddSuccessToastMessage("Product Deleted Successfully");
            return RedirectToAction("Index");
        }

        #region API Calls
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var productList = _repo.GetAll(includeProperties: "Category");
            return Json(new { data = productList });
        }
        #endregion
    }
}
