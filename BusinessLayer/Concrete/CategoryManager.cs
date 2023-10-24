using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
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
		//Eski Constructor
		//
		//EFCategoryRepo efCategoryRepo;
		//public CategoryManager()
		//{
		//	efCategoryRepo = new EFCategoryRepo();
		//}

		ICategoryDAL _categoryDAL;
		public CategoryManager(ICategoryDAL categoryDAL)
		{
			_categoryDAL = categoryDAL;
		}

		public void create(Category category)
		{
			if (category.Name != "")
			{
				_categoryDAL.create(category);
			}
			else
			{
				// Validation Error Message
			}
		}

		public void delete(Category category)
		{
			_categoryDAL.delete(category);
		}

		public List<Category> read()
		{
			return _categoryDAL.read();
		}

		public Category readById(int id)
		{
			return _categoryDAL.readById(id);
		}

		public void update(Category category)
		{
			_categoryDAL.update(category);
		}
	}
}
