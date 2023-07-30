namespace RTS.Store.Services.Data.Interfaces
{
    using RTS.Store.Web.ViewModel.Product;

    public interface IProductService
    {
        Task<IEnumerable<AllProductViewModel>> AllProductAsync();
        Task AddProductAsync(AddProductViewModel model , string sellerId);
    }
}
