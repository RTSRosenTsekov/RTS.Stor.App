namespace RTS.Store.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RTS.Store.Data.Models;
    using RTS.Store.Services.Data.Interfaces;
    using RTS.Store.Web.ViewModel.User;

    public class UserController : Controller
    {
        private readonly IUserService userService;
       
        public UserController(IUserService userService)
        {
            this.userService = userService;
          
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something error!!!");
                return this.View(model);
            }

            var createUser = await this.userService.RegisterUserAsync(model);

            if (!createUser)
            {
                return this.View(model);
            }
            
            return RedirectToAction("All", "Product");

        }

        [HttpGet]
        public async  Task<IActionResult>  Login(string? returnUrl)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return this.View(model);
            
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = await this.userService.LoginUserAsync(model);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Login is faild!");
                return this.View(model);
            }

            return RedirectToAction(model.ReturnUrl ?? "All", "Product");
        }
    }
}
