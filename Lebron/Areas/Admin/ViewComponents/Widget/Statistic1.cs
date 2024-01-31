using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace Lebron.Areas.Admin.ViewComponents.Widget
{
    public class Statistic1 : ViewComponent
    {
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.BlogCount = context.Blogs.Count();
            ViewBag.ContactCount = context.Contacts.Count();
            ViewBag.CommentCount = context.Comments.Count();

            string api = "https://api.openweathermap.org/data/2.5/weather?q=gaziantep&appid=597d7b75c438a7f47b83f645d0ade2c8&mode=xml&units=metric";
            XDocument xDocument = XDocument.Load(api);

            ViewBag.Weather = xDocument.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
    }
}
