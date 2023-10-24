using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICommentService
	{
		void create(Comment comment);
		List<Comment> read();
		Comment readById(int id);
		List<Comment> readByFilter(int id);
		void update(Comment comment);
		void delete(Comment comment);
	}
}
