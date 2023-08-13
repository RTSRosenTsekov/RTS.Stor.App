namespace RTS.Store.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using RTS.Store.Data.Models;
    using RTS.Store.Service.Data.Models.Product;
    using RTS.Store.Services.Data.Interfaces;
    using RTS.Store.Web.Data;
    using RTS.Store.Web.ViewModel.Product;
    using RTS.Store.Web.ViewModel.Product.Enums;
    using RTS.Store.Web.ViewModel.Seller;
    using System.Collections.Generic;
    using System.Linq;
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

        public async Task<AllProductFilteredAndPagedServiceModel> AllProductAsync(int page ,  AllProductQueryModel queryModel)
        {
            IQueryable<Product> productQuery = this.dbContext.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                productQuery = productQuery.Where(p => p.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchTerm))
            {
                string wildCard = $"%{queryModel.SearchTerm}%";

                productQuery = productQuery.Where(p=> EF.Functions.Like(p.Name,wildCard));
            }

            productQuery = queryModel.ProductSorting switch
            {
                ProductSorting.Newest => productQuery.OrderByDescending(p=>p.CreatedOn),
                ProductSorting.Oldest => productQuery.OrderBy(p=>p.CreatedOn),
                ProductSorting.PriceAscending => productQuery.OrderBy(p=>p.Price),
                ProductSorting.PriceDescending => productQuery.OrderByDescending(p=>p.Price),
                _=> productQuery.OrderBy(p=> p.BuyerId != null).ThenByDescending(p=>p.CreatedOn)
                

            };

            queryModel.CurrentPage = page;
            var allTotalProduct = await this.dbContext.Products.Where(p => p.IsActive).CountAsync();
            queryModel.TotalPage = (int)Math.Ceiling(allTotalProduct/ (double)queryModel.ProductPerPage);

            

            IEnumerable<AllProductViewModel> model = await productQuery.Where(p=>p.IsActive)
                .Skip((page - 1) * queryModel.ProductPerPage)
                .Take(queryModel.ProductPerPage)
                .Select(p => new AllProductViewModel
            {
                Id = p.Id.ToString(),
                Name = p.Name,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                CreateOn = p.CreatedOn
            }).ToArrayAsync();

            AllProductFilteredAndPagedServiceModel result = new AllProductFilteredAndPagedServiceModel()
            {
                Products = model
            };
            return result;
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
            product.CreatedOn = DateTime.Now;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<MineAllProductFilteredAndPageServiceModel> GetMineSellerProductAsync(MineAllProductQueryModel queryModel ,string sellerId , int page)
        {
            IQueryable<Product> productQuery = this.dbContext.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                productQuery = productQuery.Where(p => p.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchTerm))
            {
                string wildCard = $"%{queryModel.SearchTerm}%";

                productQuery = productQuery.Where(p => EF.Functions.Like(p.Name, wildCard));
            }

            productQuery = queryModel.ProductSorting switch
            {
                ProductSorting.Newest => productQuery.OrderByDescending(p => p.CreatedOn),
                ProductSorting.Oldest => productQuery.OrderBy(p => p.CreatedOn),
                ProductSorting.PriceAscending => productQuery.OrderBy(p => p.Price),
                ProductSorting.PriceDescending => productQuery.OrderByDescending(p => p.Price),
                ProductSorting.NoActive=> productQuery.OrderByDescending(p=>p.CreatedOn),
                _ => productQuery.OrderBy(p => p.BuyerId != null).ThenByDescending(p => p.CreatedOn)


            };

            var isActiv = queryModel.ProductSorting.ToString() == "NoActive" ? false : true;
            queryModel.CurrentPage = page;
            var a = queryModel.ProductSorting.ToString();
            var allTotalProduct = await this.dbContext.Products.Where(p=>p.SellerId.ToString()== sellerId).Where(p => p.IsActive == isActiv).CountAsync();
            queryModel.TotalPage = (int)Math.Ceiling(allTotalProduct / (double)queryModel.ProductPerPage);

            IEnumerable<MineAllProductViewModel> allMineProduct = await productQuery
                .Where(p => p.SellerId.ToString() == sellerId)
                .Where(p=>p.IsActive == isActiv)
                .Skip((page - 1) * queryModel.ProductPerPage)
                .Take(queryModel.ProductPerPage)
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

            MineAllProductFilteredAndPageServiceModel model = new MineAllProductFilteredAndPageServiceModel()
            {
                MineAllProducts = allMineProduct
            };

            return model;
        }

        
    }
}
