using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public class CategoryRepo_eski : ICategoryDAL
	{
		Context context = new Context();
		public void create(Category category)
		{
			context.Add(category);
			context.SaveChanges();
		}

		public List<Category> read()
		{
			return context.Categories.ToList();
		}

		public Category readById(int id)
		{
			return context.Categories.Find(id);
		}

		public void update(Category category)
		{
			context.Update(category);
			context.SaveChanges();
		}

		public void delete(Category category)
		{
			context.Remove(category);
			context.SaveChanges();
		}
	}
}