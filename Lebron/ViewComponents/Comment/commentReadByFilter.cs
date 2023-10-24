using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Comment
{
	public class commentReadByFilter : ViewComponent
	{
        public IViewComponentResult Invoke(int id)
		{
			CommentManager commentManager = new CommentManager(new EFCommentRepo());

			return View(commentManager.readByFilter(id));
		}
    }
}
