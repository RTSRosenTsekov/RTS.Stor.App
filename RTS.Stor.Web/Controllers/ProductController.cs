namespace RTS.Store.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RTS.Store.Common;
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
            
            var userId = this.User.GetId()!;
            var sellerId = await this.sellerService.GetExistSellerId(userId);

            if (sellerId == null)
            {
                TempData["Error"] = "You must be seller to add product!";
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
                TempData["Error"] = "If you wont to add product you must be seller!";
                return RedirectToAction("Become","Seller");
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

                TempData["Success"] = "You are adding product!";
                
                return RedirectToAction("Mine", "Product");
            }
            catch (Exception)
            {
                TempData["Error"]="Unexpected error occurred while trying to add your new product! Pleace try again later or contact your administrator";
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
                TempData["Error"] = "Product with the provided id dose not exist!";
                return this.RedirectToAction("All", "Product");
            }

            string userId = this.User.GetId()!;
            bool isUserSeller = await this.sellerService.SellerExistByUserIdAsync(userId);

            if (!isUserSeller)
            {
                TempData["Error"] = "If you wont to add product you must be seller!";
                return this.RedirectToAction("Become", "Product");
            }
            string? sellerId = await this.sellerService.GetExistSellerId(userId);
            bool isSellerOwnerProduct = await this.productService.IsSellerIdOwnerOfProductId(id, sellerId!);

            if (!isSellerOwnerProduct)
            {
                TempData["Error"] = "You must be seller owner of the product you want to edit!";
                return this.RedirectToAction("Mine", "Product");
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
                ModelState.AddModelError("editError", "Input model invalid!");
                return this.View(model);
            }

            try
            {
                await this.productService.EditProductByIdAsync(id, model);
                TempData["Success"] = "You are edited product!";
                return RedirectToAction("Details", "Product", new { id });
            }
            catch (Exception)
            {
               TempData["Error"]="Unexepted error occurred while trying to update the product. Please try again later or conntact administrator!";
                model.Categories = await this.categoryService.AllCategoryAsync();
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
                TempData["Error"] = "The product is not exist";
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
                TempData["Error"] = "The product is not exist";

                return RedirectToAction("All", "Product");
            }

            string userId = this.User.GetId()!;
            bool isUserSeller = await this.sellerService.SellerExistByUserIdAsync(userId);

            if (!isUserSeller)
            {
                TempData["Error"] = "If you wont to delet product you must be seller!";
                return this.RedirectToAction("Become", "Product");
            }
            string? sellerId = await this.sellerService.GetExistSellerId(userId);
            bool isSellerOwnerProduct = await this.productService.IsSellerIdOwnerOfProductId(id, sellerId!);

            if (!isSellerOwnerProduct)
            {
                TempData["Error"] = "You must be seller owner of the product you want to edit!";
                return this.RedirectToAction("Mine", "Product");
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
                TempData["Error"] = "The product is not exist";
                return RedirectToAction("All", "Product");
            }

            await this.productService.DeleteProductByIdAsync(id);

            TempData["Success"] = "You are deleted product!";
            return RedirectToAction("Mine", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            string userId = this.User.GetId()!;
            bool isUserSeller = await this.sellerService.SellerExistByUserIdAsync(userId);
            if (!isUserSeller)
            {
                TempData["Error"]="The user is not seller!";
                return this.RedirectToAction("All", "Product");
            }

            string? sellerId = await this.sellerService.GetExistSellerId(userId);
            IEnumerable<MineAllProductViewModel> model = await this.productService.GetMineSellerProductAsync(sellerId!);
            return this.View(model);
        }
    }
}
