using BusinessLayer.Authentication;
using BusinessLayer.Authorization.AuthorizeAttributes.MinimumAge;
using BusinessLayer.Authorization.AuthorizeAttributes.OnlyAnonymous;
using BusinessLayer.Authorization.Entities.Blog;
using BusinessLayer.Authorization.Entities.User;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Lebron.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Lebron.Controllers
{
    public class BlogController : DI_Base
	{
		BlogManager blogManager = new BlogManager(new EFBlogRepo());
		CategoryManager categoryManager = new CategoryManager(new EFCategoryRepo());

		public BlogController(Context context,
			IAuthorizationService authorizationService,
			UserManager<AppUser> userManager)
			: base(context, authorizationService, userManager)
		{
		}

		[BindProperty]
		public Blog Blog { get; set; }

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

		//[AllowAnonymous]
		//[Authorize]
		//[Authorize(Roles = "Admin")]
		//[Authorize(Policy = "Over18")]
		//[Authorize(AuthenticationSchemes = "scheme")]
		//[MinimumAgeAuthorize(18)]
		public async Task<IActionResult> readIncludeCategoryByAppUserFilter()
		{
			int userId = int.Parse(UserManager.GetUserId(User));

			/*var isAuthorized = await AuthorizationService
				.AuthorizeAsync(User, "Over18");*/

			/*AppUser appUser = await UserManager
				.FindByIdAsync(UserManager.GetUserId(User));
			CustomClaims customClaims = new(appUser);

			User.HasClaim(x =>
			{
				return (x.Type == customClaims.GetAge().Type) &&
					(int.Parse(x.Value) > 18);
			});*/

			/*if (User.IsInRole("Admin"))
			{
				return View(blogManager.readIncludeCategory());
			}*/

			return View(blogManager.readIncludeCategoryByAppUserFilter(userId));
		}

		#region Create
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
		public async Task<IActionResult> Create(BlogModel blogmodel)
		{
			Blog.AppUserId = Int32.Parse(UserManager.GetUserId(User));

			#region isAuthorized
			var isAuthorized = await AuthorizationService
				.AuthorizeAsync(User, Blog, BlogOperations.Create);
			if (!isAuthorized.Succeeded)
			{
				return Forbid();
			}
			#endregion

			var extension = Path.GetExtension(blogmodel.Image.FileName);
			var filename = Guid.NewGuid() + extension;
			var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/blog/image", filename);
			var stream = new FileStream(path, FileMode.Create);
			blogmodel.Image.CopyTo(stream);

			Blog.Image = filename;

			Blog.Date = DateTime.Now;
			Blog.Status = true;
			blogManager.create(Blog);

			return RedirectToAction("readIncludeCategoryByAppUserFilter", "Blog");
		}
		#endregion

		public async Task<IActionResult> Delete(int id)
		{
			Blog = blogManager.readById(id);

			#region isAuthorized
			var isAuthorized = await AuthorizationService
				.AuthorizeAsync(User, Blog, BlogOperations.Delete);

			if (!isAuthorized.Succeeded)
			{
				return Forbid();
			}
			else if (!User.Identity.IsAuthenticated)
			{
				return Challenge();
			}
			#endregion

			Blog.Status = false;

			blogManager.update(Blog);

			return RedirectToAction("readIncludeCategoryByAppUserFilter", "Blog");
		}

		#region Update
		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			Blog = blogManager.readById(id);

			#region isAuthorized
			var isAuthorized = await AuthorizationService
				.AuthorizeAsync(User, Blog, BlogOperations.Update);
			if (!isAuthorized.Succeeded)
			{
				return Forbid();
			}
			else if (!User.Identity.IsAuthenticated)
			{
				return Challenge();
			}
			#endregion

			List<SelectListItem> categoryValues = (from x in categoryManager.read()
												   select new SelectListItem
												   {
													   Text = x.Name,
													   Value = x.Id.ToString()
												   }).ToList();
			ViewBag.CategoryValues = categoryValues;

			return View(Blog);
		}
		
		[HttpPost]
		public async Task<IActionResult> Update(BlogModel blogmodel)
		{
			#region isAuthorized
			var isAuthorized = await AuthorizationService
				.AuthorizeAsync(User, Blog, BlogOperations.Update);
			if (!isAuthorized.Succeeded)
			{
				return Forbid();
			}
			else if (!User.Identity.IsAuthenticated)
			{
				return Challenge();
			}
			#endregion

			if (blogmodel.Image != null)
			{
				var extension = Path.GetExtension(blogmodel.Image.FileName);
				var filename = Guid.NewGuid() + extension;
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/blog/image", filename);
				var stream = new FileStream(path, FileMode.Create);
				blogmodel.Image.CopyTo(stream);

				Blog.Image = filename;
			}
			else
			{
				Blog.Image = Context.Blogs.AsNoTracking()
										  .Where(x => x.Id == Blog.Id)
										  .Select(x => x.Image)
										  .FirstOrDefault();
			}

			blogManager.update(Blog);

			return RedirectToAction("readIncludeCategoryByAppUserFilter", "Blog");
		}
		#endregion
	}
}
