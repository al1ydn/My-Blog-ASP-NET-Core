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
	public class Message2Manager : IMessage2Service
	{
		IMessage2DAL _message2DAL;

		public Message2Manager(IMessage2DAL message2DAL)
		{
			_message2DAL = message2DAL;
		}

		public void create(Message2 t)
		{
			throw new NotImplementedException();
		}

		public void delete(Message2 t)
		{
			throw new NotImplementedException();
		}

		public List<Message2> read()
		{
			return _message2DAL.read();
		}

		public Message2 readById(int id)
		{
			return _message2DAL.readById(id);
		}

		public List<Message2> readByReceiverFilter(int receiverId)
		{
			return _message2DAL.readByFilter(x => x.ReceiverId == receiverId);
		}

		public List<Message2> readIncludeWriterByMessage2ReceiverFilter(int receiverId)
		{
			return _message2DAL.readIncludeWriterByMessage2ReceiverFilter(receiverId);
		}

		public void update(Message2 t)
		{
			throw new NotImplementedException();
		}
	}
}
