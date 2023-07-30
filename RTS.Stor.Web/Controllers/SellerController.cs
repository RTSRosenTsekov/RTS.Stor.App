namespace RTS.Store.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RTS.Store.Services.Data.Interfaces;
    using RTS.Store.Web.Infrastricture.Extensions;
    using RTS.Store.Web.ViewModel.Seller;

    [Authorize]
    public class SellerController : Controller
    {
        private readonly ISellerService sellerService;

        public SellerController(ISellerService sellerService)
        {
                this.sellerService = sellerService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            var userId = this.User.GetId()!;
            var sellerId = await this.sellerService.GetExistSellerId(userId);
           

            if (sellerId != null)
            {
                // TO DO - Make error pages
                this.TempData["ErrorMessage"] = "You are already an agent!";
                return RedirectToAction("All", "Product");
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Become(BecomSellerViewModel model)
        {
            var userId = this.User.GetId()!;
            var sellerId = await this.sellerService.GetExistSellerId(userId);
            bool isPhoneNumberTaken = await this.sellerService.SellerExistByPhoneNumberAsync(model.PhoneNumber);
            if (sellerId!= null || isPhoneNumberTaken==true)
            {
                // TO DO - Make error pages
                this.TempData["ErrorMessage"] = "You are already an seller or phone number is exist on anather seller";
                return RedirectToAction("All", "Product");
            }

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.sellerService.CreateSellerAsync(model, userId);
                return this.RedirectToAction("All", "Product");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while registering you as an agent! Please try again later or contacted administrator.");
                return this.RedirectToAction("All", "Product");
            }
           
        }
    }
}
