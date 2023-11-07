using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Dashboard
{
	public class dashboardProfile : ViewComponent
	{
		public IViewComponentResult Invoke(int writerId)
		{
			WriterManager writerManager = new WriterManager(new EFWriterRepo());

			var mail = User.Identity.Name;
			Context context = new Context();
			var id = context.Writers.Where(x => x.Mail == mail).Select(y => y.Id).FirstOrDefault();

			return View(writerManager.readById(id));
		}
	}
}
