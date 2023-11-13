using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class Context : IdentityDbContext<AppUser, AppRole, int>
	{
		public DbSet<About> Abouts { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Writer> Writers { get; set; }
		public DbSet<Subscriber> Subscribers { get; set; }
		public DbSet<Assess> Assesses { get; set; }
		public DbSet<Notification> Notifications { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Message2> Message2s { get; set; }
		public DbSet<Admin> Admins { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder kur)
		{
			kur.UseSqlServer("server = DESKTOP-VUMO2FK\\SQLEXPRESS; database = DBBlog3; integrated security = true;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Message2>()
				.HasOne(x => x.SenderWriter)
				.WithMany(y => y.SendMessage2s)
				.HasForeignKey(z => z.SenderId)
				.OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<Message2>()
				.HasOne(x => x.ReceiverWriter)
				.WithMany(y => y.ReceivedMessage2s)
				.HasForeignKey(z => z.ReceiverId)
				.OnDelete(DeleteBehavior.ClientSetNull);

			base.OnModelCreating(modelBuilder);
		}
	}
}
