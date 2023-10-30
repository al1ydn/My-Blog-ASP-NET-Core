using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Writer
{
	public class writerNotification : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
