namespace RTS.Store.Services.Data.Interfaces
{
    using RTS.Store.Data.Models;
    using RTS.Store.Web.ViewModel.Product;

    public interface IProductService
    {
        Task<IEnumerable<AllProductViewModel>> AllProductAsync();
        Task AddProductAsync(AddProductViewModel model , string sellerId);
        Task<bool> ExistProductIdAsync(string productId);
        Task<bool> IsSellerIdOwnerOfProductId(string productId, string sellerId);
        Task<EditProductViewModel> GetEditProductAsync(string productId);
        Task<DetailsProductViewModel> GetDetailsProductAsync(string productId);
        Task EditProductByIdAsync (string productId, EditProductViewModel model);
        Task<DeleteProductViewModel> GetProductForDeleteByIdAsync(string productId);
        Task DeleteProductByIdAsync(string productId);
    }
}
