﻿using EntityLayer.Concrete;

namespace Lebron.Models
{
	public class BlogModel
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Content { get; set; }
		public string? Thumbnail { get; set; }
		public IFormFile? Image { get; set; }

		public int CategoryId { get; set; }
	}
}
