using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lebron.Controllers
{
    public class DI_Base : Controller
    {
        protected Context Context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<AppUser> UserManager { get; }

        public DI_Base(
            Context context,
            IAuthorizationService authorizationService,
            UserManager<AppUser> userManager) : base()
        {
            Context = context;
            UserManager = userManager;
            AuthorizationService = authorizationService;
        }
    }
}