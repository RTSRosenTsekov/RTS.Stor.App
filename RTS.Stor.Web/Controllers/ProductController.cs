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
                // TO DO Error message
                ModelState.AddModelError(string.Empty,"You must be seller to add product");
                return this.RedirectToAction("All", "Product");
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

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool existProductId = await this.productService.ExistProductIdAsync(id);
            if (!existProductId)
            {
                // TO do Error message "Product with the provided id dose not exist! "
                return this.RedirectToAction("All","Product");
            }

            string userId=this.User.GetId()!;
            bool isUserSeller = await this.sellerService.SellerExistByUserIdAsync(userId);

            if (!isUserSeller)
            {
                return this.RedirectToAction("Become" , "Product");
            }
            string? sellerId = await this.sellerService.GetExistSellerId(userId);
            bool isSellerOwnerProduct = await this.productService.IsSellerIdOwnerOfProductId(id, sellerId!);

            if (!isSellerOwnerProduct)
            {
                // TO DO redirect to Mine Product and error message ""You must be seller owner of the product you want to edit!""
                return this.RedirectToAction("All","Product");
            }

            EditProductViewModel model = await this.productService.GetEditProductAsync(id);
            model.Categories = await this.categoryService.AllCategoryAsync();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoryAsync();
                ModelState.AddModelError("editError" , "Input model invalid!");
                return this.View(model);
            }

            try
            {
                await this.productService.EditProductByIdAsync(id, model);
                return RedirectToAction("Details", "Product", new { id });
            }
            catch (Exception)
            {
                ModelState.AddModelError("editError", "Unexepted error occurred while trying to update the product. Please try again later or conntact administrator!");
                model.Categories= await this.categoryService.AllCategoryAsync();
                return this.View(model);
            }

            
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        { 
            bool existProduct = await this.productService.ExistProductIdAsync(id);
            if (!existProduct)
            {
                // To do error message
                return RedirectToAction("All", "Product");
            }

            DetailsProductViewModel model = await this.productService.GetDetailsProductAsync(id);

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool existProduct = await this.productService.ExistProductIdAsync(id);
            if (!existProduct)
            {
                //to do error message
                return RedirectToAction("All", "Product");
            }

            string userId = this.User.GetId()!;
            bool isUserSeller = await this.sellerService.SellerExistByUserIdAsync(userId);

            if (!isUserSeller)
            {
                return this.RedirectToAction("Become", "Product");
            }
            string? sellerId = await this.sellerService.GetExistSellerId(userId);
            bool isSellerOwnerProduct = await this.productService.IsSellerIdOwnerOfProductId(id, sellerId!);

            if (!isSellerOwnerProduct)
            {
                // TO DO redirect to Mine Product and error message ""You must be seller owner of the product you want to edit!""
                return this.RedirectToAction("All", "Product");
            }

            DeleteProductViewModel model = await this.productService.GetProductForDeleteByIdAsync(id);

            return this.View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, DeleteProductViewModel model)
        {
           

            bool existProduct = await this.productService.ExistProductIdAsync(id);
            if (!existProduct)
            {
                //to do error message
                return RedirectToAction("All", "Product");
            }

            await this.productService.DeleteProductByIdAsync(id);

            // TO DO return to mine page
            return RedirectToAction("All", "Product");
        }
    }
}
