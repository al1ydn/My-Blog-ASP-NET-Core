﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Contact
	{
        public int Id { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public string? Username { get; set; }
        public string? Mail { get; set; }
        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
    }
}
