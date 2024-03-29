﻿using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ShoppingCart.Data;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using ShoppingCart.Utility;

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
            Category category = new Category();
            if (id == null || id == 0)
            {
                return View(category);
            }
            else
            {
                 category = _repo.GetById(id.Value);

				if (category == null)
                {
                    return NotFound();
                }
                //lambda expression
                //var category1 = _context.Category.FirstOrDefault(x => x.CategoryId == id); 
                //Exmaples of Linq
                //var category2 = _context.Category.Where(category => category.Name.Contains("Comedy")).ToList();
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

                if (category.CategoryId == null || category.CategoryId == 0)
                {
                    _repo.Insert(category);
                    _toastNotification.AddSuccessToastMessage("Category Added Successfully");
                    return RedirectToAction("Index");
                }
                else
                {
                    _repo.Update(category);
                    _toastNotification.AddSuccessToastMessage("Category Updated Successfully");
                    return RedirectToAction("Index");
                }
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
            var category = _repo.GetById(id);
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
                _repo.Update(category);
                _toastNotification.AddSuccessToastMessage("Category Updated Successfully");
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
