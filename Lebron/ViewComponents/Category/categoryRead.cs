using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Category
{
	public class categoryRead : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			CategoryManager categoryManager = new CategoryManager(new EFCategoryRepo());

			return View(categoryManager.read());
		}
	}
}
