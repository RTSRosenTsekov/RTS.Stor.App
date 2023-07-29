namespace RTS.Store.Services.Data.Interfaces
{
    using RTS.Store.Web.ViewModel.User;

    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterViewModel model);
        Task<bool> LoginUserAsync(LoginViewModel model);

    }
}
