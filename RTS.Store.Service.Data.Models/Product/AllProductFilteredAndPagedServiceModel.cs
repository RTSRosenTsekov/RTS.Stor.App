namespace RTS.Store.Service.Data.Models.Product
{
    using RTS.Store.Web.ViewModel.Product;

    public class AllProductFilteredAndPagedServiceModel
    {
       public  IEnumerable<AllProductViewModel> Products { get; set; } = new HashSet<AllProductViewModel>();
    }
}
