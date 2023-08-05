namespace RTS.Store.Web.ViewModel.Product
{
    using System.ComponentModel.DataAnnotations;
    
    public  class DeleteProductViewModel
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;
    }
}
