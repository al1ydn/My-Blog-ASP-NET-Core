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
	public class MessageManager : IMessageService
	{
		IMessageDAL _messageDAL;

		public MessageManager(IMessageDAL messageDAL)
		{
			_messageDAL = messageDAL;
		}

		public void create(Message t)
		{
			throw new NotImplementedException();
		}

		public void delete(Message t)
		{
			throw new NotImplementedException();
		}

		public List<Message> read()
		{
			return _messageDAL.read();
		}

		public Message readById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Message> readByReceiverFilter(string receiver)
		{
			return _messageDAL.readByFilter(x => x.Receiver == receiver);
		}

		public void update(Message t)
		{
			throw new NotImplementedException();
		}
	}
}
