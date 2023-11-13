using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Lebron.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly ILogger<EmployeeController> _logger;

		public EmployeeController(ILogger<EmployeeController> logger)
		{
			_logger = logger;
			_logger.LogInformation("Controller visited at {DT}",
				DateTime.UtcNow.ToLongTimeString());
		}

		public async Task<IActionResult> Index()
		{
			HttpClient httpClient = new HttpClient();
			var response = await httpClient.GetAsync("https://localhost:7031/api/Default");

			var json = await response.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<EmployeeModel>>(json);

			if (response.IsSuccessStatusCode)
			{
				return View(values);
			}
			else
			{
				// Error message

				return View(values);
			}
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(EmployeeModel employeeModel)
		{
			var jsonEmployeeModel = JsonConvert.SerializeObject(employeeModel);
			StringContent stringEmployeeModel = new StringContent(jsonEmployeeModel, Encoding.UTF8, "application/json");

			HttpClient httpClient = new HttpClient();
			var response = await httpClient.PostAsync("https://localhost:7031/api/Default", stringEmployeeModel);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int writerId)
		{
			HttpClient httpClient = new HttpClient();
			var response = await httpClient.GetAsync("https://localhost:7031/api/Default/" + writerId);

			var json = await response.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<EmployeeModel>(json);

			return View(values);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(EmployeeModel employeeModel)
		{
			var jsonEmployeeModel = JsonConvert.SerializeObject(employeeModel);
			StringContent stringEmployeeModel = new StringContent(jsonEmployeeModel, Encoding.UTF8, "application/json");

			HttpClient httpClient = new HttpClient();
			var response = await httpClient.PutAsync("https://localhost:7031/api/Default", stringEmployeeModel);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int employeeId)
		{
			HttpClient httpClient = new HttpClient();
			var response = await httpClient.DeleteAsync("https://localhost:7031/api/Default/" + employeeId);

			return RedirectToAction("Index");
		}
	}

	public class EmployeeModel
	{
		public int Id { get; set; }
		public string? Name { get; set; }
	}
}
