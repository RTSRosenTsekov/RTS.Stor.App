namespace RTS.Store.Web.ViewModel.Product
{
    
    using RTS.Store.Web.ViewModel.Category;
    using RTS.Store.Web.ViewModel.Product.Enums;
    using System.ComponentModel.DataAnnotations;

    public  class AllProductQueryModel : PageListing
    {

        public AllProductQueryModel()
        {
           
            this.ProductPerPage = 3;
        }
       
        public IEnumerable<AllProductViewModel> AllProducts { get; set;} = new HashSet<AllProductViewModel>();

        public IEnumerable<AllCategoryViewModel> Categories { get; set; } = new HashSet<AllCategoryViewModel>();

        [Display(Name ="Search by text")]
        public string? SearchTerm {get;set;}

        [Display(Name ="Sort Product By")]
        public ProductSorting ProductSorting {get; set;}

        public string? Category { get; set; }

        
    }
}
