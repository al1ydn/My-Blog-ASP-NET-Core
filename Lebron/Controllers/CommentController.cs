using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lebron.Controllers
{
	[AllowAnonymous]
	public class CommentController : Controller
	{
		CommentManager commentManager = new CommentManager(new EFCommentRepo());

		// Eski yöntem
		[HttpGet]
		public PartialViewResult Create()
		{
			return PartialView();
		}
		[HttpPost]
		public IActionResult Create(Comment comment)
		{
			comment.Date = DateTime.Now;
			comment.Status = false;
			comment.BlogId = 2;

			commentManager.create(comment);

			return NoContent();
		}

		public IActionResult Add(Comment comment, int id)
		{
			comment.Date = DateTime.Now;
			comment.Status = false;
			comment.BlogId = 2;

			commentManager.create(comment);

			var returnedComment = commentManager.read().TakeLast(1).FirstOrDefault();

			return Json(JsonConvert.SerializeObject(returnedComment));
		}
	}
}
