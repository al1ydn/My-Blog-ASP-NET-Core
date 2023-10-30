using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Comment
{
	public class commentReadByBlogFilter : ViewComponent
	{
        public IViewComponentResult Invoke(int id)
		{
			CommentManager commentManager = new CommentManager(new EFCommentRepo());

			return View(commentManager.readByBlogFilter(id));
		}
    }
}
