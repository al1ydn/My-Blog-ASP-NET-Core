using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Comment
{
	public class commentRead : ViewComponent
	{
        public IViewComponentResult Invoke()
		{
			CommentManager commentManager = new CommentManager(new EFCommentRepo());
			
			var values = commentManager.read();

			return View(values);
		}
    }
}
