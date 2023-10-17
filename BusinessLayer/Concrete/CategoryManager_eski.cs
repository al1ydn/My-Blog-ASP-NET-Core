using BusinessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CategoryManager_eski : ICategoryService
	{
		GenericRepo<Category> categoryRepo = new GenericRepo<Category>();

		public void create(Category category)
		{
			if (category.Name != "")
			{
				categoryRepo.create(category);
			}
			else
			{
				// Validation Error Message
			}
		}

		public void delete(Category category)
		{
			categoryRepo.delete(category);
		}

		public List<Category> read()
		{
			return categoryRepo.read();
		}

		public Category readById(int id)
		{
			return categoryRepo.readById(id);
		}

		public void update(Category category)
		{
			categoryRepo.update(category);
		}
	}
}
