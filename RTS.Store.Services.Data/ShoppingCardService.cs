namespace RTS.Store.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualBasic;
    using RTS.Store.Data.Models;
    using RTS.Store.Services.Data.Interfaces;
    using RTS.Store.Web.Data;
    using RTS.Store.Web.ViewModel.ShoppingCard;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ShoppingCardService : IShoppingCardService
    {
        private readonly StoreDbContext dbContext;

        public ShoppingCardService(StoreDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<string> AddProductToShoppingCardAsync(string productId, string userId, decimal quantity)
        {
            var product = await this.dbContext.Products.Where(p=> p.Id.ToString()==productId).FirstOrDefaultAsync();

            var shopingCard = await GetShoppingCardWithUserIdAsync(userId);

            for (int i = 0; i < quantity; i++)
            {
                //shopingCard.Products.Add(product!);
                //product!.QuantityInStock = product.QuantityInStock - 1;
                //await dbContext.SaveChangesAsync();
            }

            //  вземане на всички шопинг карти.
            //var res = this.dbContext.ShopingCards.Select(ob => new {  
            //
            //    ob.Products,
            //    ob.ShipingAddress
            //
            //}).ToArray();

            return "OK";
        }

        public async Task<bool> ExistQuantityInStockAsync(string productId, decimal quantity)
        {
            var result = await this.dbContext.Products.Where(p => p.Id.ToString() == productId).AnyAsync(p=> quantity <= p.QuantityInStock);
           
            return result;
        }

        public async Task<ShopingCard> GetShoppingCardWithUserIdAsync(string userId)
        {
            var shCard = await this.dbContext.ShopingCards.Where(sc=>sc.UserId! == userId ).FirstOrDefaultAsync();

            if (shCard == null )
            {
                var user = await this.dbContext.Users.Where(u=>u.Id == userId).FirstOrDefaultAsync();

                var newShCard = new ShopingCard()
                {
                    //ShipingAddress = user.Address == null ? "No address" : user.Address,
                    //Status = "NewShCard",
                    //UserId = userId,
                };

                await this.dbContext.ShopingCards.AddAsync(newShCard);
                await this.dbContext.SaveChangesAsync();
                return newShCard;
            }
            return shCard;
        }
    }
}
