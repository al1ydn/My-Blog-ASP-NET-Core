using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ISubscriberService
	{
		void create(Subscriber subscriber);
		List<Subscriber> read();
		Subscriber readById(int id);
		List<Subscriber> readByFilter(int id);
		void update(Subscriber subscriber);
		void delete(Subscriber subscriber);
	}
}
