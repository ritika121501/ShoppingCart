﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCart.Data;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using ShoppingCart.Utility;

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
        public IActionResult CreateProduct()
        {
            //SelectListItem
            IEnumerable<SelectListItem> categoryList = _cateRepo.GetAll().Select(u=> new SelectListItem
            { 
                Text = u.Name,
                Value = u.CategoryId.ToString()
            });
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if (product.Title != null && product.Title.ToLower().Contains(ConstantValues.TestData.ToLower()))
            {
                ModelState.AddModelError("Title", "Test is not a valid input");
            }
            if (ModelState.IsValid)
            {
                _repo.Insert(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //LINQ
            if(id==0)
            { 
                return NotFound();
            }
            var Product = _repo.GetById(id);
            if(Product == null)
            {
                return NotFound();
            }
            //lambda expression
            //var Product1 = _context.Product.FirstOrDefault(x => x.ProductId == id); 
            //Exmaples of Linq
            //var Product2 = _context.Product.Where(Product => Product.Name.Contains("Comedy")).ToList();
            return View(Product);
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
