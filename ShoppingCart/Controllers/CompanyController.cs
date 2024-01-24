using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using ShoppingCart.Utility;
using ShoppingCart.ViewModels;

namespace ShoppingCart.Controllers
{
	public class CompanyController : Controller
	{
		private readonly IRepository<Company> _repo;		
		private readonly IToastNotification _toastNotification;

		public CompanyController(IRepository<Company> repo,	IToastNotification toastNotification)
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
		public IActionResult UpsertCompany(int? id)
		{
			Company company = new Company();
			
			if (id == null || id == 0)
			{
				return View(company);
			}
			else
			{
				company = _repo.GetById(id.Value);

				if (company == null)
				{
					return NotFound();
				}
				return View(company);
			}
		}

		[HttpPost]
		public IActionResult UpsertCompany(Company company)
		{
			if (company.CompanyName != null && company.CompanyName.ToLower().Contains(ConstantValues.TestData.ToLower()))
			{
				ModelState.AddModelError("CompanyName", "Test is not a valid input");
			}

			if (string.IsNullOrWhiteSpace(company.CompanyName))
			{
				ModelState.AddModelError("CompanyName", "Title yet to be decided");

			}
						
			if (ModelState.IsValid)
			{
				
				
				if (company.CompanyId == 0)
				{
					_repo.Insert(company);
					_toastNotification.AddSuccessToastMessage("Company Added Successfully");
					return RedirectToAction("Index");
				}
				else
				{
					_repo.Update(company);
					_toastNotification.AddSuccessToastMessage("Company Updated Successfully");
					return RedirectToAction("Index");
				}

			}
					
			return View();
		}

		[HttpGet]
		public IActionResult Delete(int Id)
		{
			Company company = new Company();
			company = _repo.GetById(Id);						
			_repo.Delete(company);
			_toastNotification.AddSuccessToastMessage("Company Deleted Successfully");
			return RedirectToAction("Index");
		}






		#region API Calls
		[HttpGet]
		public IActionResult GetAllCompany()
		{
			var companyList = _repo.GetAll();
			return Json(new { data = companyList });
		}
		#endregion
	}
}
