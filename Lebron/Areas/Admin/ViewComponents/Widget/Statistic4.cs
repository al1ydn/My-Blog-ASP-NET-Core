using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Areas.Admin.ViewComponents.Widget
{
    public class Statistic4 : ViewComponent
    {
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.AdminName = context.Admins.Where(x => x.Id == 1).Select(y => y.Name).FirstOrDefault();
            ViewBag.AdminImage = context.Admins.Where(x => x.Id == 1).Select(y => y.Image).FirstOrDefault();
            ViewBag.AdminAbout = context.Admins.Where(x => x.Id == 1).Select(y => y.About).FirstOrDefault();

            return View();
        }
    }
}
