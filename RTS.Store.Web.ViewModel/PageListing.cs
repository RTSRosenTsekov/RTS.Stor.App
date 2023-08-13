namespace RTS.Store.Web.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public  class PageListing
    {
        public int CurrentPage { get; set; }

        public int TotalPage { get; set; }

        public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPage ? this.TotalPage : this.CurrentPage + 1;

        [Display(Name="Show Product on Page")]
        public int ProductPerPage { get; set; } 
    }
}
