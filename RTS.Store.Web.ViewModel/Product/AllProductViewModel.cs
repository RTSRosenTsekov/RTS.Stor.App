namespace RTS.Store.Web.ViewModel.Product
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public  class AllProductViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; }= null!;

        public string Description { get; set; }= null!;

        [Display(Name ="Image Url")]
        public string ImageUrl { get; set; } = null!;

        public decimal? Price { get; set; }

        [Display(Name="Create On")]
        public DateTime CreateOn { get; set; }  

    }
}
