using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Dashboard
{
	public class dashboardKarma : ViewComponent
	{
		public IViewComponentResult Invoke(int writerId)
		{
			AssessManager assessManager = new AssessManager(new EFAssessRepo());

			return View(assessManager.readByWriterFilter(writerId));
		}
	}
}
