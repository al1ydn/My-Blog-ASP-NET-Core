using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Writer
{
	public class writerAbout : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var userName = User.Identity.Name;

			Context context = new Context();
			var writerId = context.Writers.Where(x => x.UserName == userName)
				.Select(x => x.Id)
				.FirstOrDefault();
			
			WriterManager writerManager = new WriterManager(new EFWriterRepo());
			return View(writerManager.readById(writerId));
		}
	}
}
