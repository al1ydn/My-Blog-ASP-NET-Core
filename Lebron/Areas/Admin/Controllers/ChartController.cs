using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Lebron.Areas.Admin.Models;
using Lebron.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ChartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult CreateJsonCategories()
		{
			List<CategoryModel> categories = new List<CategoryModel>();

            using (var context = new Context())
            {
                categories = context.Categories.Select(x => new CategoryModel
                {
                    Name = x.Name,
                    BlogCount = 5,
                }).ToList();
            }

            return Json(new { jsonCategories = categories });
		}
	}
}
