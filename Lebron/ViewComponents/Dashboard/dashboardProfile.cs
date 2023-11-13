using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Dashboard
{
	public class dashboardProfile : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			// Identity'den önce
			//var mail = User.Identity.Name;

			var userName = User.Identity.Name;

			Context context = new Context();
			var id = context.Writers.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();

			WriterManager writerManager = new WriterManager(new EFWriterRepo());
			return View(writerManager.readById(id));
		}
	}
}
