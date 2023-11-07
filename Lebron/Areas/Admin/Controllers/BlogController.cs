using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using Lebron.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

//namespace eklemedim

[Area("Admin")]
public class BlogController : Controller
{
	BlogManager blogManager = new BlogManager(new EFBlogRepo());

	public IActionResult Index(int page = 1)
	{
		return View(blogManager.readIncludeCategory().ToPagedList(page, 15));
	}

	public IActionResult ExportToExcel()
	{
		using (var workbook = new XLWorkbook())
		{
			List<BlogModel> blogModels = new List<BlogModel>();
			//{
			//	new BlogModel {Id=8, Title="Deneme"}
			//};

			using (var context = new Context())
			{
				blogModels = context.Blogs.Select(x => new BlogModel
				{
					Id = x.Id,
					Title = x.Title,
				}).ToList();
			}

			var worksheet = workbook.Worksheets.Add("Sayfa 1");

			worksheet.Cell(1, 1).Value = "ID";
			worksheet.Cell(1, 2).Value = "TITLE";

			int row = 2;
			foreach (var item in blogModels)
			{
				worksheet.Cell(row, 1).Value = item.Id;
				worksheet.Cell(row, 2).Value = item.Title;
				row++;
			}

			using (var stream = new MemoryStream())
			{
				workbook.SaveAs(stream);
				var content = stream.ToArray();
				return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Blog Listesi.xlsx");
			}
		}
	}
}
