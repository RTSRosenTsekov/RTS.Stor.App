namespace RTS.Store.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using RTS.Store.Services.Data.Interfaces;
    using RTS.Store.Web.Data;
    using RTS.Store.Web.ViewModel.Product;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly StoreDbContext dbContext;

        public ProductService(StoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<AllProductViewModel>> AllProductAsync()
        {
            var model = await this.dbContext.Products.Select(p => new AllProductViewModel
            {
                Id=p.Id.ToString(),
                Name=p.Name,
                Description=p.Description,
                ImageUrl=p.ImageUrl,
                Price=p.Price,
                CreateOn=p.CreatedOn
            }).ToArrayAsync();
            
            return model;
        }
    }
}
