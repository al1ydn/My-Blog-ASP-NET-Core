using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lebron.Controllers
{
    public class DashboardController : Controller
    {
        Context context = new Context();
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(Context context, UserManager<AppUser> userManager)
        {
            this.context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //var userName = User.Identity.Name;
            //var writerId = context.Writers.Where(x => x.UserName == userName)
            //	                          .Select(x => x.Id)
            //							  .FirstOrDefault();

            //ViewBag.BlogCountWeek = context.Blogs.Where(x => (x.Date > DateTime.Now.AddDays(-7)))
            //	                                 .Where(x => x.WriterId == writerId).Count();
            //ViewBag.BlogCountTotal = context.Blogs.Where(x => x.WriterId == writerId).Count();
            //ViewBag.dashboardKarmaWriterId = writerId;

            var appUserId = Int32.Parse(_userManager.GetUserId(User));

            ViewBag.BlogCountWeek = context.Blogs.Where(x => (x.Date > DateTime.Now.AddDays(-7)))
                                                 .Where(x => x.AppUserId == appUserId).Count();
            ViewBag.BlogCountTotal = context.Blogs.Where(x => x.AppUserId == appUserId).Count();
            ViewBag.dashboardKarmaWriterId = appUserId;

            return View();
        }
    }
}
