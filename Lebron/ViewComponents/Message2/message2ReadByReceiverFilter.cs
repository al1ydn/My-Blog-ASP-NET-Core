using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Message
{
    public class message2ReadByReceiverFilter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Message2Manager message2Manager = new Message2Manager(new EFMessage2Repo());

            return View(message2Manager.readByReceiverFilter(7));
        }
    }
}
