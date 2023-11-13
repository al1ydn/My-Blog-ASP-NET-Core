using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Writer
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? About { get; set; }
        public string? Image { get; set; }
        public string? Mail { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
        public bool? Status { get; set; }
        public string? UserName { get; set; }

        public List<Blog> Blogs { get; set; }

        public virtual ICollection<Message2> SendMessage2s { get; set; }
        public virtual ICollection<Message2> ReceivedMessage2s { get; set; }
    }
}
