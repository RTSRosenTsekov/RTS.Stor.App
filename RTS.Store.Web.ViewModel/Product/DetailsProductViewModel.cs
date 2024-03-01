namespace RTS.Store.Web.ViewModel.Product
{
    using RTS.Store.Web.ViewModel.Seller;
    using System.ComponentModel.DataAnnotations;

    public  class DetailsProductViewModel : AllProductViewModel
    {
                
        [Display(Name = "Quantity in stock")]
        public decimal? QuantityInStock { get; set; }

        public decimal? Quantity { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }

        public string CategoryName { get; set; } = null!;

        public SellerInfoViewModel Seller {get;set;} = null!;
    }
}
