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
	public class BlogManager : IBlogService
	{
		IBlogDAL _blogDAL;

		public BlogManager(IBlogDAL blogDAL)
		{
			_blogDAL = blogDAL;
		}

		public void create(Blog blog)
		{
			_blogDAL.create(blog);
		}

		public void delete(Blog blog)
		{
			_blogDAL.delete(blog);
		}

		public List<Blog> read()
		{
			return _blogDAL.read();
		}

		public Blog readById(int id)
		{
			return _blogDAL.readById(id);
		}

		public List<Blog> readByFilter(int id)
		{
			return _blogDAL.readByFilter(x => x.Id == id);
		}

		public List<Blog> readByWriterFilter(int id)
		{
			return _blogDAL.readByFilter(x => x.WriterId == id);
		}

		public List<Blog> readIncludeCategory()
		{
			return _blogDAL.readIncludeCategory();
		}

		public void update(Blog blog)
		{
			_blogDAL.update(blog);
		}
	}
}
