namespace RTS.Store.Web.ViewModel.Seller
{
    using System.ComponentModel.DataAnnotations;

    public  class BecomSellerViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 7)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;
    }
}
