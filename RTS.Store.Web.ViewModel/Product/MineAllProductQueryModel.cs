namespace RTS.Store.Web.ViewModel.Product
{
    using RTS.Store.Web.ViewModel.Category;
    using RTS.Store.Web.ViewModel.Product.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class MineAllProductQueryModel : PageListing
    {

        public MineAllProductQueryModel()
        {

            this.ProductPerPage = 3;
        }

        public IEnumerable<MineAllProductViewModel> AllProducts { get; set; } = new HashSet<MineAllProductViewModel>();

        public IEnumerable<AllCategoryViewModel> Categories { get; set; } = new HashSet<AllCategoryViewModel>();

        [Display(Name = "Search by text")]
        public string? SearchTerm { get; set; }

        [Display(Name = "Sort Product By")]
        public ProductSorting ProductSorting { get; set; }

        public string? Category { get; set; }

    }
}
