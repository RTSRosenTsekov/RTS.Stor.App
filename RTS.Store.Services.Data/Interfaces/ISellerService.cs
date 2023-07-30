namespace RTS.Store.Services.Data.Interfaces
{
    using RTS.Store.Web.ViewModel.Seller;

    public interface ISellerService
    {
        Task CreateSellerAsync(BecomSellerViewModel model, string userId);
        Task<string?> GetExistSellerId(string userId);
        Task<bool> SellerExistByPhoneNumberAsync(string phoneNumber);
        Task<bool> SellerExistByUserIdAsync(string userId);
    }
}
