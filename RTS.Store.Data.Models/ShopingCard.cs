namespace RTS.Store.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ShopingCard
    {

        [Key]
        public Guid Id { get; set; }

        public decimal? OrderTotal { get; set; }

        [Required]
        public string ShipingAddress { get; set; } = null!;

        public string? Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }=new HashSet<Product>();

        public Guid UserId { get; set; }

        public AplicationUser User { get; set; } = null!;

        public int PaymentId { get; set; }

        public Payment Payment { get; set; } = null!;
    }
}
