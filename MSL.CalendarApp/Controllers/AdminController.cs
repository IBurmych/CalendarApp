using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MSL.CalendarApp.Controllers
{
    public class AdminController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;
        private IHttpContextAccessor _httpContextAccessor;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> SetAdmin()
        {
            IdentityRole? adminRole = await _roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
            }
            if (!User.IsInRole("Admin"))
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser != null)
                {
                    await _userManager.AddToRoleAsync(currentUser, "Admin");
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
