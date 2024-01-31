using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Blog
{
	public class blogReadByAppUserFilter : ViewComponent
	{
		public IViewComponentResult Invoke(int id)
		{
			BlogManager blogManager = new BlogManager(new EFBlogRepo());

			return View(blogManager.readByAppUserFilter(id));
		}
	}
}
