using _77CarRental.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _77CarRental.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;

        public AccountController(UserManager<Users> userManager,SignInManager<Users> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel newuser)
        {
            if (ModelState.IsValid)
            {
                //create a new application user object using the viewmodel data
                //since the applicationuser entity model is mapped to the DB table AspNetUser
                var user = new Users
                {
                    FirstName = newuser.FirstName,
                    LastName = newuser.LastName,
                    UserName = newuser.Email,
                    Email = newuser.Email
                };
                //user CreateAsync method to create a new user
                var result = await userManager.CreateAsync(user, newuser.Password);
                if (result.Succeeded)
                {
                    //add the newly registered user to the "Member" Role
                    IdentityResult roleResult = await userManager.AddToRoleAsync(user, "Member");
                    //signin user and redirect to home page
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                //If any errors occurred then add errors to the model state.
                foreach (var error in result.Errors)
                {
                    //errors will be display in the validation summary
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(newuser);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginuser)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginuser.Email, loginuser.Password, loginuser.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "home");
                }
                //if signin is unsuccessful, add an error to the modelstate,
                //it will be displayed in the validation summary
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(loginuser);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
