namespace RTS.Store.Web.ViewModel.Seller
{
    using System.ComponentModel.DataAnnotations;

    public  class SellerInfoViewModel
    {
        [Display(Name ="Full Name")]
        public string FullName { get; set; }= null!;

        public string Email { get; set; } = null!;

        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; } = null!;
    }
}
