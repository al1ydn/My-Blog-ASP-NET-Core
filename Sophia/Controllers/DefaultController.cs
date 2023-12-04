using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sophia.DAL;
using System;

namespace Sophia.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DefaultController : ControllerBase
	{
		[HttpGet("[action]")]
		public IActionResult Login()
		{
			return Created("", new BuildToken().CreateToken());
		}

		[Authorize]
		[HttpGet("[action]")]
		public IActionResult Page1()
		{
			return Ok("Success");
		}
	}
}
