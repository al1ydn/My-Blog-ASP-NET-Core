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
	public class AboutManager : IAboutService
	{
		IAboutDAL _aboutDAL;

		public AboutManager(IAboutDAL aboutDAL)
		{
			_aboutDAL = aboutDAL;
		}

		public void create(About t)
		{
			throw new NotImplementedException();
		}

		public void delete(About t)
		{
			throw new NotImplementedException();
		}

		public List<About> read()
		{
			return _aboutDAL.read();
		}

		public About readById(int id)
		{
			throw new NotImplementedException();
		}

		public void update(About t)
		{
			throw new NotImplementedException();
		}
	}
}
