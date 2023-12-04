using EntityLayer.Concrete;

namespace Lebron.Areas.Admin.Models
{
	public class SetRoleViewModel
	{
		public List<string>? UserUserNames { get; set; }
		public string? SelectedUserUserName { get; set; }
		public List<string>? RoleNames { get; set; }
		public IList<string>? SelectedRoleNames { get; set; }
	}
}
