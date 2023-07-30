namespace RTS.Store.Services.Data.Interfaces
{
    using RTS.Store.Web.ViewModel.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<AllCategoryViewModel>> AllCategoryAsync();
    }
}
