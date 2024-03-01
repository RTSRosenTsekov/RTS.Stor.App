namespace RTS.Store.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ShopingCard
    {

        [Key]
        public Guid Id { get; set; }
          
        [Required]
        public string ShipingAddress { get; set; } = null!;
                
        public virtual ICollection<Order> Order { get; set; }=new HashSet<Order>();

        public string? UserId { get; set; }

        public ApplicationUser? User { get; set; } = null!;

        public Guid? PaymentId { get; set; }

        public virtual Payment? Payment { get; set; } = null!;
    }
}
