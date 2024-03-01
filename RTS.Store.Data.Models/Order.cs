namespace RTS.Store.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new HashSet<ProductOrder>();

        public decimal? OrderTotal { get; set; }

        public string? Status { get; set; }

        public Guid ShopingCardId { get; set; }

        public ShopingCard ShopingCard { get; set; }= null!;        


    }
}
