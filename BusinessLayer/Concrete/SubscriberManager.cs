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
	public class SubscriberManager : ISubscriberService
	{
		ISubscriberDAL _subscriberDAL;

		public SubscriberManager(ISubscriberDAL subscriberDAL)
		{
			_subscriberDAL = subscriberDAL;
		}

		public void create(Subscriber subscriber)
		{
			_subscriberDAL.create(subscriber);
		}

		public void delete(Subscriber t)
		{
			throw new NotImplementedException();
		}

		public List<Subscriber> read()
		{
			throw new NotImplementedException();
		}

		public Subscriber readById(int id)
		{
			throw new NotImplementedException();
		}

		public void update(Subscriber t)
		{
			throw new NotImplementedException();
		}
	}
}
