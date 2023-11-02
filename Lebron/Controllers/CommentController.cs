using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Controllers
{
	public class CommentController : Controller
	{
		CommentManager commentManager = new CommentManager(new EFCommentRepo());

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public PartialViewResult Create()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult Create(Comment comment)
		{
			comment.Date = DateTime.Now;
			comment.Status = true;
			comment.BlogId = 2;

			commentManager.create(comment);

			return PartialView();
		}
	}
}
