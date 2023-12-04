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

        public List<Blog> Blogs { get; set; }

		public virtual ICollection<Message2> SendMessage2s { get; set; }
		public virtual ICollection<Message2> ReceivedMessage2s { get; set; }
	}
}
