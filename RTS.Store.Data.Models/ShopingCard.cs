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

        public string? UserId { get; set; }

        public ApplicationUser? User { get; set; } = null!;

        public Guid? PaymentId { get; set; }

        public virtual Payment? Payment { get; set; } = null!;
    }
}
