namespace RTS.Store.Web.ViewModel.Product
{
    using RTS.Store.Web.ViewModel.Category;
    using System.ComponentModel.DataAnnotations;
    
    public  class AddProductViewModel
    {
       
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(2048)]
        public string ImageUrl { get; set; } = null!;

       
        [Range(typeof(decimal),"0" , "1000000")]
        public decimal? Price { get; set; }

        [Required]
        [Range(typeof(decimal),"0", "1000")]
        [Display(Name="Quantity in stock")]
        public decimal? QuantityInStock { get; set; }
                
        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }

        [Display(Name="Category")]
        public int CategoryId {get; set; }

        public IEnumerable<AllCategoryViewModel> Categories { get; set; } = new HashSet<AllCategoryViewModel>();
    }
}
