using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Message
{
    public class message2ReadIncludeWriterByMessage2ReceiverFilter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Message2Manager message2Manager = new Message2Manager(new EFMessage2Repo());

            return View(message2Manager.readIncludeWriterByMessage2ReceiverFilter(7));
        }
    }
}
