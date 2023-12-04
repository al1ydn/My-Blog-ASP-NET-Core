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
		public List<Message2> readIncludeUserByMessage2ReceiverFilter(int receiverId)
		{
			using(var context = new Context())
			{
				return context.Message2s.Include(x => x.SenderAppUser)
										.Where(x => x.AppUserReceiverId == receiverId)
										.ToList();
			}
		}

		public List<Message2> readIncludeUserByMessage2SenderFilter(int senderId)
		{
			using (var context = new Context())
			{
				return context.Message2s.Include(x => x.ReceiverAppUser)
										.Where(x => x.AppUserSenderId == senderId)
										.ToList();
			}
		}
	}
}
