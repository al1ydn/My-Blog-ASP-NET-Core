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
	public class WriterManager : IWriterService
	{
		IWriterDAL _writerDAL;

		public WriterManager(IWriterDAL writerDAL)
		{
			_writerDAL = writerDAL;
		}

		public void create(Writer writer)
		{
			_writerDAL.create(writer);
		}

		public void delete(Writer writer)
		{
			throw new NotImplementedException();
		}

		public List<Writer> read()
		{
			return _writerDAL.read();
		}

		public Writer readById(int id)
		{
			throw new NotImplementedException();
		}

		public void update(Writer writer)
		{
			throw new NotImplementedException();
		}
	}
}
