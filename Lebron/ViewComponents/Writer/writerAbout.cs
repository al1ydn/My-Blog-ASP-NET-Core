using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lebron.ViewComponents.Writer
{
	public class writerAbout : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			WriterManager writerManager = new WriterManager(new EFWriterRepo());

			return View(writerManager.readById(1));
		}
	}
}
