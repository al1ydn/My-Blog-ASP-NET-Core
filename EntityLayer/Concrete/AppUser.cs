using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class AppUser : IdentityUser<int>
	{
		public string? Name { get; set; }
		public string? About { get; set; }
		public string? Image { get; set; }
		public string? Password { get; set; }
	}
}
