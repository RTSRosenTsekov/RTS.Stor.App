namespace RTS.Store.Web.ViewModel.Product
{
    using System.ComponentModel.DataAnnotations;

    public  class MineAllProductViewModel : AllProductViewModel
    {
        [Display(Name="Is Active")]
        public bool IsActive { get; set; }
    }
}
