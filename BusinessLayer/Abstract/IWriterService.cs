using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IWriterService
	{
		void create(Writer writer);
		List<Writer> read();
		Writer readById(int id);
		void update(Writer writer);
		void delete(Writer writer);
	}
}
