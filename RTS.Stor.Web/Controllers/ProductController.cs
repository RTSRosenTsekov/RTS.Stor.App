namespace RTS.Store.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RTS.Store.Services.Data.Interfaces;
    using RTS.Store.Web.Infrastricture.Extensions;
    using RTS.Store.Web.ViewModel.Product;

    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ISellerService sellerService;
        private readonly IUserService userService;

        public ProductController(IProductService productService, ICategoryService categoryService, IUserService userService, ISellerService sellerService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.userService = userService;
            this.sellerService = sellerService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var result = await this.productService.AllProductAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            // TO DO : Only Seller add product ;
            var userId = this.User.GetId()!;
            var sellerId = await this.sellerService.GetExistSellerId(userId);
            if (sellerId == null)
            {

            }
            var allCategory = await this.categoryService.AllCategoryAsync();

            AddProductViewModel model = new AddProductViewModel()
            {
                Categories = allCategory
            };


            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            var userId = this.User.GetId()!;
            var sellerId = await this.sellerService.GetExistSellerId(userId);
            if (sellerId == null)
            {
                // TO do redirect to make seller 
                var allCategory = await this.categoryService.AllCategoryAsync();
                model.Categories = allCategory;
                return View(model);
            }

            //TO DO Ochek category 
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Model is invalid.");
                var allCategory = await this.categoryService.AllCategoryAsync();
                model.Categories = allCategory;
                return this.View(model);
            }
           
           try
           {
               await this.productService.AddProductAsync(model, sellerId!);
           
              // TO DO return to all seller adding product
              return RedirectToAction("All","Product");
           }
           catch (Exception)
           {
           
               this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while tryningto //add your new house! Pleace try again later or contact your administrator");
               var allCategory = await this.categoryService.AllCategoryAsync();
               model.Categories = allCategory;
               return this.View(model);
           }
           

        }
    }
}
