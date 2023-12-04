using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IMessage2Service : IGenericService<Message2>
	{
		List<Message2> readByReceiverFilter(int receiverId);
		public List<Message2> readIncludeUserByMessage2ReceiverFilter(int receiverId);
		public List<Message2> readIncludeUserByMessage2SenderFilter(int senderId);
	}
}
