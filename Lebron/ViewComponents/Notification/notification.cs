using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Notification
{
    public class notification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            NotificationManager notificationManager = new NotificationManager(new EFNotificationRepo());

            return View(notificationManager.read());
        }
    }
}
