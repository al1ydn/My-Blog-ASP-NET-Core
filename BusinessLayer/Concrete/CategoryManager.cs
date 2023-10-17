using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CategoryManager : ICategoryService
	{
		EFCategoryRepo efCategoryRepo;

		public CategoryManager()
		{
			efCategoryRepo = new EFCategoryRepo();
		}

		public void create(Category category)
		{
			if (category.Name != "")
			{
				efCategoryRepo.create(category);
			}
			else
			{
				// Validation Error Message
			}
		}

		public void delete(Category category)
		{
			efCategoryRepo.delete(category);
		}

		public List<Category> read()
		{
			return efCategoryRepo.read();
		}

		public Category readById(int id)
		{
			return efCategoryRepo.readById(id);
		}

		public void update(Category category)
		{
			efCategoryRepo.update(category);
		}
	}
}
