using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	public class CategoryController : Controller
	{
		CategoryManager categoryManager = new CategoryManager(new EFCategoryRepo());

		public IActionResult Index()
		{
			return View(categoryManager.read());
		}
	}
}
