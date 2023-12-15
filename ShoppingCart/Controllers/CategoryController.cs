﻿using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Data;
using ShoppingCart.Models;
using ShoppingCart.Utility;

namespace ShoppingCart.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ShoppingCartContext _context;

        public CategoryController(ShoppingCartContext context)
        {
            _context = context;
        }
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
        public IActionResult CreateCategory(Category category)
        {
            if (category.Name != null && category.Name.ToLower().Contains(ConstantValues.TestData.ToLower()))
            {
                ModelState.AddModelError("Name", "Test is not a valid input");
            }
            if (ModelState.IsValid)
            {
                _context.Category.Add(category);
                _context.SaveChanges();
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
            var category = _context.Category.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            //lambda expression
            //var category1 = _context.Category.FirstOrDefault(x => x.CategoryId == id); 
            //Exmaples of Linq
            //var category2 = _context.Category.Where(category => category.Name.Contains("Comedy")).ToList();
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
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id, string name)
        {
            var a = _context.Category.Where(i => (i.DisplayOrder == id && i.Name == name)).FirstOrDefault();

            if (a != null)
            {
                _context.Category.Remove(a);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    
    }
}