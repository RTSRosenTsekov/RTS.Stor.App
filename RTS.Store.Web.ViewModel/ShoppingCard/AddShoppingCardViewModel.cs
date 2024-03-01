namespace RTS.Store.Web.ViewModel.ShoppingCard
{
    using RTS.Store.Data.Models;
    public class AddShoppingCardViewModel
    {
        public IEnumerable<Product> ShoppingProduct { get; set; } = new HashSet<Product>();
    }
}
