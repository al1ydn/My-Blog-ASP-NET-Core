using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Message2
	{
        public int Id { get; set; }
        public string? Subject { get; set; }
        public string? Detail { get; set; }
        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
        public bool? isRead { get; set; }

        public int? SenderId { get; set; }
        public Writer SenderWriter { get; set; }
        public int? ReceiverId { get; set; }
		public Writer ReceiverWriter { get; set; }

		public int? AppUserSenderId { get; set; }
		public AppUser SenderAppUser { get; set; }
		public int? AppUserReceiverId { get; set; }
		public AppUser ReceiverAppUser { get; set; }
	}
}
