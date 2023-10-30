using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IGenericService<T> where T : class
	{
		void create(T t);
		List<T> read();
		T readById(int id);
		void update(T t);
		void delete(T t);
	}
}
