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
	public class CommentManager : ICommentService
	{
		ICommentDAL _commentDAL;

		public CommentManager(ICommentDAL commentDAL)
		{
			_commentDAL = commentDAL;
		}

		public void create(Comment comment)
		{
			_commentDAL.create(comment);
		}

		public void delete(Comment t)
		{
			throw new NotImplementedException();
		}

		public List<Comment> read()
		{
			return _commentDAL.read();
		}

		public Comment readById(int id)
		{
			throw new NotImplementedException();
		}

		public void update(Comment t)
		{
			throw new NotImplementedException();
		}

		public List<Comment> readByBlogFilter(int id)
		{
			return _commentDAL.readByFilter(x => x.BlogId == id);
		}
	}
}
