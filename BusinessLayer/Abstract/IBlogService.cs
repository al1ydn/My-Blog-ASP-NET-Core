using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IBlogService : IGenericService<Blog>
	{
		//List<Blog> readByFilter(Expression<Func<Blog, bool>> filer);
		List<Blog> readByFilter(int id);
		List<Blog> readByWriterFilter(int id);
		List<Blog> readByLatestFilter(int id);

		List<Blog> readIncludeCategory();
		List<Blog> readIncludeCategoryByAppUserFilter(int id);
	}
}
