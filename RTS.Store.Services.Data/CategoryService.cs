using RTS.Store.Services.Data.Interfaces;

namespace RTS.Store.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using RTS.Store.Web.Data;
    using RTS.Store.Web.ViewModel.Category;

    public class CategoryService : ICategoryService
    {
        private readonly StoreDbContext dbContext;

        public CategoryService(StoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<AllCategoryViewModel>> AllCategoryAsync()
        {
            var allCategory = await dbContext.Categories.Select(c => new AllCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
            }).ToArrayAsync();

            return allCategory;
        }
    }
}
