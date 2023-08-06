namespace RTS.Store.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using RTS.Store.Data.Models;
    using RTS.Store.Services.Data.Interfaces;
    using RTS.Store.Web.Data;
    using RTS.Store.Web.ViewModel.Product;
    using RTS.Store.Web.ViewModel.Seller;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly StoreDbContext dbContext;

        public ProductService(StoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddProductAsync(AddProductViewModel model, string sellerId)
        {

            Product product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                QuantityInStock = model.QuantityInStock,
                IsActive = true,
                CreatedOn = DateTime.UtcNow,
                CategoryId = model.CategoryId,
                // SellerId = Guid.Parse(sellerId)
            };

            product.SellerId = Guid.Parse(sellerId);
            await this.dbContext.Products.AddAsync(product);
            await this.dbContext.SaveChangesAsync();



        }

        public async Task<IEnumerable<AllProductViewModel>> AllProductAsync()
        {
            var model = await this.dbContext.Products.Where(p=>p.IsActive).Select(p => new AllProductViewModel
            {
                Id = p.Id.ToString(),
                Name = p.Name,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                CreateOn = p.CreatedOn
            }).ToArrayAsync();

            return model;
        }

        public async Task<EditProductViewModel> GetEditProductAsync(string productId)
        {
            Product product = await this.dbContext.Products.Include(c => c.Category).Where(c => c.IsActive).FirstAsync(p => p.Id.ToString() == productId);

            EditProductViewModel result = new EditProductViewModel()
            {
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                IsActive = product.IsActive,
                CreatedOn = product.CreatedOn,
                QuantityInStock = product.QuantityInStock,
                CategoryId = product.CategoryId

            };

            return result;
        }

        public async Task<bool> ExistProductIdAsync(string productId)
        {
            bool existProduct = await this.dbContext.Products.AnyAsync(p => p.Id.ToString() == productId);

            return existProduct;
        }

        public async Task<bool> IsSellerIdOwnerOfProductId(string productId, string sellerId)
        {
            bool result = await this.dbContext.Products.Where(p => p.IsActive == true).AnyAsync(p => p.Id.ToString() == productId && p.SellerId.ToString() == sellerId);

            return result;
        }

        public async Task<DetailsProductViewModel> GetDetailsProductAsync(string productId)
        {
            Product product = await this.dbContext.Products
                .Include(c => c.Category)
                .Include(s => s.Seller)
                .ThenInclude(u => u.User)
                .Where(a => a.IsActive)
                .FirstAsync(p => p.Id.ToString() == productId);

            DetailsProductViewModel detailsProductViewModel = new DetailsProductViewModel()
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                CreateOn= product.CreatedOn,
                IsActive = product.IsActive,
                QuantityInStock = product.QuantityInStock,
                Price = product.Price,
                CategoryName = product.Category.Name,
                Seller = new SellerInfoViewModel 
                { 
                    FullName= product.Seller.User.FirstName + " " + product.Seller.User.LastName,
                    Email = product.Seller.User.Email,
                    PhoneNumber = product.Seller.PhoneNumber
                
                }

            };

            return detailsProductViewModel;
        }

        public async Task EditProductByIdAsync(string productId, EditProductViewModel model)
        {
            Product currentProduct = await this.dbContext.Products.Where(h=>h.IsActive).FirstAsync(p => p.Id.ToString() == productId);

            currentProduct.Name= model.Name;
            currentProduct.Description= model.Description;
            currentProduct.ImageUrl= model.ImageUrl;
            currentProduct.Price= model.Price;
            currentProduct.QuantityInStock= model.QuantityInStock;
            currentProduct.CreatedOn = DateTime.Now;
            currentProduct.CategoryId = model.CategoryId;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<DeleteProductViewModel> GetProductForDeleteByIdAsync(string productId)
        {
            Product product = await this.dbContext.Products.Where(c => c.IsActive).FirstAsync(p => p.Id.ToString() == productId);

            DeleteProductViewModel model = new DeleteProductViewModel()
            { 
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
            };

            return model;
        }

        public async Task DeleteProductByIdAsync(string productId)
        {
            Product product = await this.dbContext.Products.Where(p => p.IsActive).FirstAsync(p => p.Id.ToString() == productId);

            product.IsActive = false;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<MineAllProductViewModel>> GetMineSellerProductAsync(string sellerId)
        {
            IEnumerable<MineAllProductViewModel> allMineProduct = await this.dbContext.Products
                .Where(p => p.SellerId.ToString() == sellerId)
                .Select(p => new MineAllProductViewModel() 
                { 
                    Id=p.Id.ToString(),
                    Name= p.Name,
                    Description= p.Description,
                    ImageUrl= p.ImageUrl,
                    Price = p.Price,
                    CreateOn = p.CreatedOn,
                    IsActive = p.IsActive
                
                })
                .ToListAsync();

            return allMineProduct;
        }
    }
}
