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
	public class AssessManager : IAssessService
	{
		IAssessDAL _assessDAL;

		public AssessManager(IAssessDAL assessDAL)
		{
			_assessDAL = assessDAL;
		}

		public void create(Assess t)
		{
			throw new NotImplementedException();
		}

		public void delete(Assess t)
		{
			throw new NotImplementedException();
		}

		public List<Assess> read()
		{
			return _assessDAL.read();
		}

		public Assess readById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Assess> readByAppUserFilter(int id)
		{
			return _assessDAL.readByFilter(x => x.AppUserId == id);
		}

		public void update(Assess t)
		{
			throw new NotImplementedException();
		}
	}
}
