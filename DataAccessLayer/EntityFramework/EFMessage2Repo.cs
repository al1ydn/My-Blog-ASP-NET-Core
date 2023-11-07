using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EFMessage2Repo : GenericRepo<Message2>, IMessage2DAL
	{
		public List<Message2> readIncludeWriterByMessage2ReceiverFilter(int receiverId)
		{
			using(var context = new Context())
			{
				return context.Message2s.Include(x => x.SenderWriter).Where(x => x.ReceiverId == receiverId).ToList();
			}
		}
	}
}
