using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.Areas.Admin.ViewComponents.Widget
{
    public class Statistic4 : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
