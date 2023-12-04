using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IMessage2DAL : IGenericDAL<Message2>
	{
		public List<Message2> readIncludeUserByMessage2ReceiverFilter(int receiverId);
		public List<Message2> readIncludeUserByMessage2SenderFilter(int senderId);
	}
}
