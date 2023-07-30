namespace RTS.Store.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using RTS.Store.Data.Models;
    using RTS.Store.Services.Data.Interfaces;
    using RTS.Store.Web.Data;
    using RTS.Store.Web.ViewModel.Seller;
    using System;
    using System.Threading.Tasks;

    public class SellerService : ISellerService
    {
        private readonly StoreDbContext dbContext;

        public SellerService(StoreDbContext dbContext)
        {
                this.dbContext = dbContext;
        }

        public async Task CreateSellerAsync(BecomSellerViewModel model, string userId)
        {
            Seller newSeller = new Seller()
            { 
                UserId=userId,
                PhoneNumber=model.PhoneNumber
            };

            await dbContext.Sellers.AddAsync(newSeller);
            await dbContext.SaveChangesAsync();
        }

        public async Task<string?> GetExistSellerId(string userId)
        {
            Seller? sellerId = await this.dbContext.Sellers.FirstOrDefaultAsync(u => u.UserId == userId);

            if (sellerId==null)
            {
                return null;
            }
            return sellerId.Id.ToString();
        }

        public async Task<bool> SellerExistByPhoneNumberAsync(string phoneNumber)
        {
            bool phoneNumberExist = await dbContext.Sellers.AnyAsync(p => p.PhoneNumber == phoneNumber);
            return phoneNumberExist;
        }

        public async Task<bool> SellerExistByUserIdAsync(string userId)
        {
            var result = await dbContext.Sellers.AnyAsync(u => u.UserId == userId);

            return result;
        }
    }
}
