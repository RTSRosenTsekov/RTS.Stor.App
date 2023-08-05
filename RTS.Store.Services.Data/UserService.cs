namespace RTS.Store.Services.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using RTS.Store.Data.Models;
    using RTS.Store.Services.Data.Interfaces;
    using RTS.Store.Web.Data;
    using RTS.Store.Web.ViewModel.User;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManeger;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly StoreDbContext  dbContext;

        public UserService(UserManager<ApplicationUser> userManeger , SignInManager<ApplicationUser> signInManager, StoreDbContext dbContext)
        {
            this.userManeger = userManeger;
            this.signInManager = signInManager;
            this.dbContext = dbContext;
        }

        

        public async Task<bool> LoginUserAsync(LoginViewModel model)
        {
            var result = await this.signInManager.PasswordSignInAsync(model.Email , model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                return false;
            }



            return true;
        }

        public async Task<bool> RegisterUserAsync(RegisterViewModel model)
        {
            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Adress
            };

            await this.userManeger.SetUserNameAsync(user, model.Email);
            await this.userManeger.SetEmailAsync(user, model.Email);

            IdentityResult result = await this.userManeger.CreateAsync(user, model.Password);
            
            if (!result.Succeeded)
            {
                return false;
            }
            await signInManager.SignInAsync(user , false);
            return true;
        }


    }
}
