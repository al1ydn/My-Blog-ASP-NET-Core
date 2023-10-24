using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IBlogService
	{
		void create(Blog blog);
		List<Blog> read();
		Blog readById(int id);
		//List<Blog> readByFilter(Expression<Func<Blog, bool>> filer);
		List<Blog> readByFilter(int id);
		List<Blog> readByWriterFilter(int id);
		void update(Blog blog);
		void delete(Blog blog);

		List<Blog> readIncludeCategory();
	}
}
