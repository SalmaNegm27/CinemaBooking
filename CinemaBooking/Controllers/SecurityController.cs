using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Net;


namespace CinemaBooking.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SecurityController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public SecurityController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RolesViewModels model)
        {
            if(ModelState.IsValid)
            {
            await _roleManager.CreateAsync(new IdentityRole(model.RoleName.Trim()));
          return  RedirectToAction(nameof(Index));

            }
            return View(model);
        }
        //public async Task<IActionResult> Delete(string roleName)
        //{
        //    var role = await _roleManager.FindByIdAsync(roleName);


        //    if (role == null)
        //    {
        //        return View("NotFound");
        //    }

        //    return View(role);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public  async Task<IActionResult> DeleteConfirmed(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                return View("Not Found");
            }

            Task<IdentityResult>? result = _roleManager.DeleteAsync(role);

            if (result.IsCompletedSuccessfully)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View("Not Found");
            }

        }
    }
}
