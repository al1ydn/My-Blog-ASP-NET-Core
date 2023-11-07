using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Areas.Admin.ViewComponents.Widget
{
    public class Statistic2 : ViewComponent
    {
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.RecentWriter = context.Writers.OrderByDescending(x => x.Id).Select(x => x.Name).Take(1).FirstOrDefault();

            return View();
        }
    }
}
