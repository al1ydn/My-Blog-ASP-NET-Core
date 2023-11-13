using Microsoft.EntityFrameworkCore;

namespace Honda.DataAccessLayer
{
	public class Context : DbContext
	{
		public DbSet<Employee> Employees { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder kur)
		{
			kur.UseSqlServer("server = DESKTOP-VUMO2FK\\SQLEXPRESS; database = DBBlog3API; integrated security = true;");
		}
	}
}
