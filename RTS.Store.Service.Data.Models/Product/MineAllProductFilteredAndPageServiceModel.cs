namespace RTS.Store.Service.Data.Models.Product
{
    using RTS.Store.Web.ViewModel.Product;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public  class MineAllProductFilteredAndPageServiceModel
    {
       public IEnumerable<MineAllProductViewModel> MineAllProducts { get; set; } = new HashSet<MineAllProductViewModel>();
    }
}
