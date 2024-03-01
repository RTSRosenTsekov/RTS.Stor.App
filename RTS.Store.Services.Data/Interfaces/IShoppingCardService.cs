namespace RTS.Store.Services.Data.Interfaces
{
    using RTS.Store.Data.Models;
    using RTS.Store.Web.ViewModel.ShoppingCard;

    public interface IShoppingCardService
    {
        Task<string> AddProductToShoppingCardAsync(string productId , string userId, decimal quantity);
        Task<bool> ExistQuantityInStockAsync(string productId, decimal quantity);
        Task<ShopingCard> GetShoppingCardWithUserIdAsync(string userId);
    }
}
