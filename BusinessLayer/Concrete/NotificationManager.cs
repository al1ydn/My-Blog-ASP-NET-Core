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
	public class NotificationManager : INotificationService
	{
		INotificationDAL _notificationDAL;

		public NotificationManager(INotificationDAL notificationDAL)
		{
			_notificationDAL = notificationDAL;
		}

		public void create(Notification t)
		{
			throw new NotImplementedException();
		}

		public void delete(Notification t)
		{
			throw new NotImplementedException();
		}

		public List<Notification> read()
		{
			return _notificationDAL.read();
		}

		public Notification readById(int id)
		{
			throw new NotImplementedException();
		}

		public void update(Notification t)
		{
			throw new NotImplementedException();
		}
	}
}
