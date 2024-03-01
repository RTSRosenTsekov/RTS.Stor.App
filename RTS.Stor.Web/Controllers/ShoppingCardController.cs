namespace RTS.Store.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RTS.Store.Services.Data.Interfaces;
    using RTS.Store.Web.Infrastricture.Extensions;

    public class ShoppingCardController : Controller
    {
        private readonly IShoppingCardService shoppingCardService;
        private readonly IProductService productService;

        public ShoppingCardController(IShoppingCardService shoppingCardService, IProductService productService)
        {
            this.shoppingCardService = shoppingCardService;
            this.productService = productService;

        }

        [HttpPost]
        public async Task<IActionResult> AddToCard(string id, decimal quantity)
        {
            var existProductId = await this.productService.ExistProductIdAsync(id);
            
            if (!existProductId)
            {
                TempData["Error"] = "Something went wrong";
                return RedirectToAction("All", "Product");
            }
            var existQuantityInStock = await this.shoppingCardService.ExistQuantityInStockAsync(id,quantity);
            if (!existQuantityInStock) 
            {
                TempData["Error"] = "Quantity in stock is less more then you want to order. Please choose other quantity.";
                return RedirectToAction("Details", "Product" , new {id});
            }

            var userId = this.User.GetId()!;
            if (userId== null)
            {
                return RedirectToAction("Login", "User");
            }

            var result = await this.shoppingCardService.AddProductToShoppingCardAsync(id, userId, quantity);
            if (result == "OK")
            {
                TempData["Success"] = "You are adding product to your shoppinc card!";
                return RedirectToAction("All", "Product");
            }
            else
            {
                TempData["Error"] = "Unexpected error occurred while trying to add your new product to shopping card! Please try again later or contact your administrator";
                return RedirectToAction("All", "Product");
            }

        }
    }
}
