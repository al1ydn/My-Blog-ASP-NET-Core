using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Writer
{
	public class writerMessageNotification : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
