using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Message
{
    public class message2ReadIncludeUserByMessage2ReceiverFilter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
			var userName = User.Identity.Name;

			Context context = new Context();
			var userId = context.Users.Where(x => x.UserName == userName)
                                        .Select(x => x.Id)
                                        .FirstOrDefault();

			Message2Manager message2Manager = new Message2Manager(new EFMessage2Repo());

            var unreadMessages = message2Manager.readIncludeUserByMessage2ReceiverFilter(userId)
                                                .Where(x => x.isRead == false)
                                                .ToList();

			return View(unreadMessages); // Butona basıldığında yenilenmesini istiyorum.
        }
    }
}
