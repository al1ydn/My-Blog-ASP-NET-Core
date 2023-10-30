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
	public class ContactManager : IContactService
	{
		IContactDAL _contactDAL;

		public ContactManager(IContactDAL contactDAL)
		{
			_contactDAL = contactDAL;
		}

		public void create(Contact contact)
		{
			_contactDAL.create(contact);
		}

		public void delete(Contact t)
		{
			throw new NotImplementedException();
		}

		public List<Contact> read()
		{
			throw new NotImplementedException();
		}

		public Contact readById(int id)
		{
			throw new NotImplementedException();
		}

		public void update(Contact t)
		{
			throw new NotImplementedException();
		}
	}
}
