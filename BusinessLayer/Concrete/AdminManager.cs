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
	public class AdminManager : IAdminService
	{
		IAdminDAL _adminDAL;

		public AdminManager(IAdminDAL adminDAL)
		{
			_adminDAL = adminDAL;
		}

		public void create(Admin t)
		{
			throw new NotImplementedException();
		}

		public void delete(Admin t)
		{
			throw new NotImplementedException();
		}

		public List<Admin> read()
		{
			throw new NotImplementedException();
		}

		public Admin readById(int id)
		{
			throw new NotImplementedException();
		}

		public void update(Admin t)
		{
			throw new NotImplementedException();
		}
	}
}
