using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Lebron.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lebron.Controllers
{
	public class BlogController : Controller
	{
		BlogManager blogManager = new BlogManager(new EFBlogRepo());
		CategoryManager categoryManager = new CategoryManager(new EFCategoryRepo());

		[AllowAnonymous]
		public IActionResult Index()
		{
			return View(blogManager.readIncludeCategory());
		}

		[AllowAnonymous]
		public IActionResult Detail(int id)
		{
			ViewBag.blogId = id;
			return View(blogManager.readByFilter(id));
		}

		public IActionResult readIncludeCategoryByAppUserFilter(int writerId)
		{
			var userName = User.Identity.Name;
			Context context = new Context();
			var userId = context.Users.Where(x => x.UserName == userName)
										.Select(x => x.Id)
										.FirstOrDefault();

			return View(blogManager.readIncludeCategoryByAppUserFilter(userId));
		}

		[HttpGet]
		public IActionResult Create()
		{
			List<SelectListItem> categoryValues = (from x in categoryManager.read()
												   select new SelectListItem
												   {
													   Text = x.Name,
													   Value = x.Id.ToString()
												   }).ToList();
			ViewBag.CategoryValues = categoryValues;
			
			return View();
		}
		[HttpPost]
		public IActionResult Create(BlogModel blogmodel)
		{
			var extension = Path.GetExtension(blogmodel.Image.FileName);
			var filename = Guid.NewGuid() + extension;
			var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/blog/image", filename);
			var stream = new FileStream(path, FileMode.Create);
			blogmodel.Image.CopyTo(stream);

			Blog blog = new Blog();
			
			blog.Image = filename;
			blog.Title = blogmodel.Title;
			blog.CategoryId = blogmodel.CategoryId;
			blog.Thumbnail = blogmodel.Thumbnail;
			blog.Content = blogmodel.Content;

			blog.Status = true;
			blog.Date = DateTime.Now;

			blog.WriterId = 2;

			blogManager.create(blog);

			return RedirectToAction("readIncludeCategoryByWriterFilter", "Blog");
		}

		public IActionResult Delete(int id)
		{
			Blog selectedBlog = blogManager.readById(id);
			selectedBlog.Status = false;

			blogManager.update(selectedBlog);

			return RedirectToAction("readIncludeCategoryByAppUserFilter", "Blog");
		}

		[HttpGet]
		public IActionResult Update(int id)
		{
			List<SelectListItem> categoryValues = (from x in categoryManager.read()
												   select new SelectListItem
												   {
													   Text = x.Name,
													   Value = x.Id.ToString()
												   }).ToList();
			ViewBag.CategoryValues = categoryValues;

			Blog blog = blogManager.readById(id);

			return View(blog);
		}
		[HttpPost]
        public IActionResult Update(BlogModel blogmodel)
		{
			var extension = Path.GetExtension(blogmodel.Image.FileName);
			var filename = Guid.NewGuid() + extension;
			var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/blog/image", filename);
			var stream = new FileStream(path, FileMode.Create);
			blogmodel.Image.CopyTo(stream);

			Blog blog = new Blog();
			blog.Image = filename;
			blog.Title = blogmodel.Title;
			blog.CategoryId = blogmodel.CategoryId;
			blog.Thumbnail = blogmodel.Thumbnail;
			blog.Content = blogmodel.Content;

			blog.Id = blogmodel.Id;
			blog.Date = blogmodel.Date;
			blog.Status = blogmodel.Status;
			blog.WriterId = blogmodel.WriterId;

			blogManager.update(blog);

            return RedirectToAction("readIncludeCategoryByWriterFilter", "Blog");
        }
    }
}
