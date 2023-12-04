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
	public class AppUserManager : IAppUserService
	{
		IAppUserDAL _appUserDAL;

		public AppUserManager(IAppUserDAL appUserDAL)
		{
			_appUserDAL = appUserDAL;
		}

		public void create(AppUser t)
		{
			throw new NotImplementedException();
		}

		public void delete(AppUser t)
		{
			throw new NotImplementedException();
		}

		public List<AppUser> read()
		{
			throw new NotImplementedException();
		}

		public AppUser readById(int id)
		{
			throw new NotImplementedException();
		}

		public void update(AppUser t)
		{
			throw new NotImplementedException();
		}
	}
}
