using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Lebron.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		CategoryManager categoryManager = new CategoryManager(new EFCategoryRepo());

		public IActionResult Index(int page = 1)
		{
			return View(categoryManager.read().ToPagedList(page, 15));
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(Category category)
		{
			CategoryValidator categoryValidator = new CategoryValidator();
			ValidationResult validationResult = categoryValidator.Validate(category);

			if (validationResult.IsValid)
			{
				categoryManager.create(category);

				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}

				return View();
			}
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			return View(categoryManager.readById(id));
		}
		[HttpPost]
		public IActionResult Edit(Category category)
		{
			CategoryValidator categoryValidator = new CategoryValidator();
			ValidationResult validationResult = categoryValidator.Validate(category);

			if (validationResult.IsValid)
			{
				categoryManager.create(category);

				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}

				return View();
			}
		}

		public IActionResult EditStatus(int id)
		{
			Category category = categoryManager.readById(id);
			category.Status = !(category.Status);

			categoryManager.update(category);

			return RedirectToAction("Index");
		}
	}
}
