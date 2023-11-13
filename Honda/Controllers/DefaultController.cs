using Honda.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Honda.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DefaultController : ControllerBase
	{
		[HttpGet]
		public IActionResult Read()
		{
			using var context = new Context();
			var values = context.Employees.ToList();

			return Ok(values);
		}
		
		[HttpPost]
		public IActionResult Create(Employee employee)
		{
			using var context = new Context();

			context.Add(employee);
			context.SaveChanges();

			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult ReadById(int id)
		{
			using var context = new Context();

			var selectedEmployee = context.Employees.Find(id);

			if (selectedEmployee != null)
			{
				return Ok(selectedEmployee);
			}
			else
			{
				return NotFound();
			}
		}
		
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			using var context = new Context();

			var selectedEmployee = context.Employees.Find(id);

			if (selectedEmployee != null)
			{
				context.Remove(selectedEmployee);
				context.SaveChanges();

				return Ok();
			}
			else
			{
				return NotFound();
			}
		}

		[HttpPut]
		public IActionResult Update(Employee employee)
		{
			using var context = new Context();

			var selectedEmployee = context.Find<Employee>(employee.Id);

			if (selectedEmployee != null)
			{
				selectedEmployee.Name = employee.Name;
				context.Update(selectedEmployee);
				context.SaveChanges();

				return Ok();
			}
			else
			{
				return NotFound();
			}
		}
	}
}
