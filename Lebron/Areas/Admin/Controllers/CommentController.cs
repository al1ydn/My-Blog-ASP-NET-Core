using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CommentController : Controller
	{
		CommentManager commentManager = new CommentManager(new EFCommentRepo());

		public IActionResult Read()
		{
			return View(commentManager.read());
		}
	}
}
