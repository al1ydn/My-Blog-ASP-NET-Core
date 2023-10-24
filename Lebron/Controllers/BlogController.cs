using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	public class BlogController : Controller
	{
		BlogManager blogManager = new BlogManager(new EFBlogRepo());

		public IActionResult Index()
		{
			return View(blogManager.readIncludeCategory());
		}

		public IActionResult Detail(int id)
		{
			ViewBag.blogId = id;
			return View(blogManager.readByFilter(id));
		}
	}
}
