using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Lebron.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Lebron.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager writerManager = new WriterManager(new EFWriterRepo());

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Writer writer)
		{
			WriterValidator writerValidator = new WriterValidator();
			ValidationResult validationResult = writerValidator.Validate(writer);
			
			if (validationResult.IsValid)
			{
			writer.Status = false;

			writerManager.create(writer);
			
			return RedirectToAction("Index", "Blog");
			}
			else
			{
				foreach(var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}

				return View();
			}
		}
	}
}
