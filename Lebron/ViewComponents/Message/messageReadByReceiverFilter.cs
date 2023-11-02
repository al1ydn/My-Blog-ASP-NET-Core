using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Message
{
    public class messageReadByReceiverFilter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            MessageManager messageManager = new MessageManager(new EFMessageRepo());

            return View(messageManager.readByReceiverFilter("elif"));
        }
    }
}
