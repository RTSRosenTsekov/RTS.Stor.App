namespace RTS.Store.Services.Data.Interfaces
{
    using RTS.Store.Data.Models;
    using RTS.Store.Service.Data.Models.Product;
    using RTS.Store.Web.ViewModel.Product;

    public interface IProductService
    {
        Task <AllProductFilteredAndPagedServiceModel> AllProductAsync(int page ,  AllProductQueryModel queryModel);
        Task AddProductAsync(AddProductViewModel model , string sellerId);
        Task<bool> ExistProductIdAsync(string productId);
        Task<bool> IsSellerIdOwnerOfProductId(string productId, string sellerId);
        Task<EditProductViewModel> GetEditProductAsync(string productId);
        Task<DetailsProductViewModel> GetDetailsProductAsync(string productId);
        Task EditProductByIdAsync (string productId, EditProductViewModel model);
        Task<DeleteProductViewModel> GetProductForDeleteByIdAsync(string productId);
        Task DeleteProductByIdAsync(string productId);
        Task<MineAllProductFilteredAndPageServiceModel> GetMineSellerProductAsync(MineAllProductQueryModel queryModel,string sellerId , int page);
    }
}
