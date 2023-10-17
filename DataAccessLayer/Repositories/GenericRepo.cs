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
	public class GenericRepo<T> : IGenericDAL<T> where T : class
	{
		Context context = new Context();

		public void create(T t)
		{
			context.Add(t);
			context.SaveChanges();
		}

		public List<T> read()
		{
			return context.Set<T>().ToList();
		}

		public T readById(int id)
		{
			return context.Set<T>().Find(id);
		}

		public void update(T t)
		{
			context.Update(t);
			context.SaveChanges();
		}

		public void delete(T t)
		{
			context.Remove(t);
			context.SaveChanges();
		}
	}
}
