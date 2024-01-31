using EntityLayer.Concrete;
using Lebron.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BusinessLayer.Authorization;

namespace Lebron.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class RoleController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;
		private readonly UserManager<AppUser> _userManager;

		public RoleController(RoleManager<AppRole> roleManager, 
			UserManager<AppUser> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		public IActionResult GetList()
		{
			//IList<string> rolesOfUser = await _userManager.GetRolesAsync(selectedUser);

			List<AppRole> roles = _roleManager.Roles.ToList();

			/*
			List<RoleModel> roleModels = new List<RoleModel>();
			foreach(var item in roles)
			{
				RoleModel roleModel = new RoleModel();
				roleModel.Name = item.Name;
				roleModel.Id = item.Id;

				roleModels.Add(roleModel);
			}
			*/

			var rolesJson = JsonConvert.SerializeObject(roles);
			List<RoleModel>? roleModels = JsonConvert.DeserializeObject<List<RoleModel>>(rolesJson);

			return View(roleModels);
		}

		#region Add
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		
		[HttpPost]
		public async Task<IActionResult> Add(AppRole appRole)
		{
			await _roleManager.CreateAsync(appRole);

			return RedirectToAction("GetList");
		} 
		#endregion

		public async Task<IActionResult> Delete(string name)
		{
			AppRole selectedRole = await _roleManager.FindByNameAsync(name);

			await _roleManager.DeleteAsync(selectedRole);

			return RedirectToAction("GetList");
		}

		#region Update
		[HttpGet]
		public async Task<IActionResult> Update(string name)
		{
			AppRole appRole = await _roleManager.FindByNameAsync(name);

			string appRoleJson = JsonConvert.SerializeObject(appRole);
			RoleModel? roleModel = JsonConvert.DeserializeObject<RoleModel>(appRoleJson);
			
			return View(roleModel);
		}
		
		[HttpPost]
		public async Task<IActionResult> Update(AppRole newAppRole)
		{
			AppRole toUpdateAppRole = 
				await _roleManager.FindByIdAsync(newAppRole.Id.ToString());
			toUpdateAppRole.Name = newAppRole.Name;

			await _roleManager.UpdateAsync(toUpdateAppRole);

			return RedirectToAction("GetList");
		} 
		#endregion

		#region SetRole
		[HttpGet]
		public IActionResult SetRole()
		{
			SetRoleViewModel setRoleViewModel = new SetRoleViewModel();
			setRoleViewModel.UserUserNames = _userManager.Users.Select(x => x.UserName).ToList();

			return View(setRoleViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> SetRole(SetRoleViewModel setRoleViewModel)
		{
			/*
			//Get users with theirs roles
			List<AppUser> users = _userManager.Users.ToList();
			IList<IList<string>> roles = new List<IList<string>>();
			foreach (var item in users)
			{
				IList<string> rolesOfUser = new List<string>();
				rolesOfUser = await _userManager.GetRolesAsync(item);
				roles.Add(rolesOfUser);
			}
			*/

			if (setRoleViewModel.SelectedUserUserName == null)
			{
				return UnprocessableEntity();
			}

			foreach (var roleName in setRoleViewModel.SelectedRoleNames)
			{
				if (roleName == null)
				{
					return UnprocessableEntity();
				}

				bool isExist = await _roleManager.RoleExistsAsync(roleName);
				if (!isExist)
				{
					return UnprocessableEntity();
				}
			}


			AppUser selectedUser = await _userManager
				.FindByNameAsync(setRoleViewModel.SelectedUserUserName);

			IList<string> rolesOfUser = await _userManager
				.GetRolesAsync(selectedUser);
			IdentityResult identityResult1 = await _userManager
				.RemoveFromRolesAsync(selectedUser, rolesOfUser);

			if (setRoleViewModel.SelectedRoleNames != null)
			{
				await _userManager.AddToRolesAsync(
					selectedUser, 
					setRoleViewModel.SelectedRoleNames);
			}

			setRoleViewModel.UserUserNames = 
				_userManager.Users.Select(x => x.UserName).ToList();
			setRoleViewModel.RoleNames = 
				_roleManager.Roles.Select(x => x.Name).ToList();

			return View(setRoleViewModel);
		}

		public async Task<PartialViewResult> GetRolesOfUser(string userName)
		{
			AppUser selectedUser = 
				await _userManager.FindByNameAsync(userName);
			IList<string> rolesOfUser = 
				await _userManager.GetRolesAsync(selectedUser);

			SetRoleViewModel setRoleViewModel = new SetRoleViewModel();
			setRoleViewModel.SelectedRoleNames = rolesOfUser;
			setRoleViewModel.RoleNames = 
				_roleManager.Roles.Select(x => x.Name).ToList();

			return PartialView(setRoleViewModel);
		} 
		#endregion
	}
}
