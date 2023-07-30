
using CinemaBooking.Contexts;
using CinemaBooking.Data.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaBooking.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SecurityController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SecurityController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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
            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(new IdentityRole(model.RoleName.Trim()));
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }

        #region getAllRoles
        //public ActionResult GetAllRoles()
        //{
        //    string[] roles = _roleManager.Roles.Select(r => r.Name).ToArray();
        //    return View(roles);
        //}

        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                return View("Not Found");
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View("NotFound");
            }

        }

        public IActionResult AddUser()
        {
            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();

            var viewModel = new RegisterUserViewModel
            {
                RolesList = allRoles.Select(role => new SelectListItem { Value = role, Text = role }).ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.EmailAddress,
                    FullName = model.FullName,
                    Email = model.EmailAddress
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                    await _userManager.AddToRoleAsync(user, model.SelectedRole);


                    return RedirectToAction("GetAllUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            model.RolesList = _roleManager.Roles.Select(role => new SelectListItem { Value = role.Name, Text = role.Name }).ToList();
            return View(model);
        }


        public async Task<IActionResult> GetAllUsers()
        {
            //var roles = await _roleManager.Roles.ToListAsync();
            //List<ApplicationUser>? users = await  _userManager.Users.ToListAsync();
            List<ApplicationUser>? users = await _userManager.Users.ToListAsync();
            List<UserWithRolesViewModel>? usersWithRoles = new List<UserWithRolesViewModel>();

            foreach (var user in users)
            {
                IList<string>? userRoles = await _userManager.GetRolesAsync(user);
                List<string>? roleNames = await _roleManager.Roles
                                                .Where(role => userRoles.Contains(role.Name))
                                                .Select(role => role.Name)
                                                 .ToListAsync();
                var userWithRoles = new UserWithRolesViewModel
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Roles = roleNames
                };
                usersWithRoles.Add(userWithRoles);
            }

            return View(usersWithRoles);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return View("Not Found");
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("GetAllUsers");
            }
            else
            {
                return View("NotFound");
            }

        }
    }
}
