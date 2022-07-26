using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TNexus.Web.Areas.Account.Models;
using TNexus.Web.Database;


namespace TNexus.Web.Areas.Account.Controllers
{
    [Area("Account")]
    [Route("account/[controller]/[action]")]
    public class IdentityController : Controller
    {

        /* 23. Sledeci nas korak jeste da kreiramo usermanager i signinmanager koji cemo koristiti
         * za manipulisanjem korisnika prilikom logovanja i kreiranja korisnika*/
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public IdentityController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        #region HttpGet Methods

        //Putanja za pristup stranice: Registration
        [AllowAnonymous]
        public IActionResult Registration()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Home", "Index");
            }
            return View();
        }

        //Putanja za pristup stranice: Login
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Home", "Index");
            }
            return View();
        }

        #endregion HttpGet Methods

        #region HttpPost Methods

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, PhoneNumber = model.Telephone, FirstName = model.FirstName, LastName = model.LastName };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var roleResult = await userManager.AddToRoleAsync(user, "UserRegular");

                if (roleResult.Succeeded)
                {
                    TempData["Response"] = true;
                    TempData["ResponseMessage"] = "User sucsesfully Registered!";
                }
                else
                {
                    TempData["Response"] = false;
                    foreach (var item in result.Errors)
                    {
                        TempData["ResponseMessage"] += "<p>" + item.Description + "</p>";
                    }
                }
            }
            else
            {
                TempData["Response"] = false;
                foreach (var item in result.Errors)
                {
                    TempData["ResponseMessage"] += "<p>" + item.Description + "</p>";
                }

            }

            return View();
        }
        //teodorA12334456#

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                ViewBag.User = userManager.GetUserAsync(User);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Response"] = false;
                TempData["ResponseMessage"] = result;
            }

            return View();
        }

        #endregion HttpPost Methods

    }
}