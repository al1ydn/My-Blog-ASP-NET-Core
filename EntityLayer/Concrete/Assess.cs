using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Assess
	{
        public int Id { get; set; }
        public int? Score { get; set; }
        public int? Count { get; set; }
        public int BlogId { get; set; }
        public int AppUserId { get; set; }
    }
}
