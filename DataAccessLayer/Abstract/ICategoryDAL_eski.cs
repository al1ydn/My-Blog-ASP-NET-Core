using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface ICategoryDAL_eski
	{
		void create(Category category);
		List<Category> read();
		Category readById(int id);
		void update(Category category);
		void delete(Category category);
	}
}