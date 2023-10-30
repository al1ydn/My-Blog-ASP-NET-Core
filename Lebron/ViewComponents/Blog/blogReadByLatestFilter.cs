using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Blog
{
	public class blogReadByLatestFilter : ViewComponent
	{
		public IViewComponentResult Invoke(int count)
		{
			BlogManager blogManager = new BlogManager(new EFBlogRepo());

			return View(blogManager.readByLatestFilter(count));
		}
	}
}
