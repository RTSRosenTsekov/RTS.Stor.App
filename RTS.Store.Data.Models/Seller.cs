namespace RTS.Store.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Seller
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 7)]
        public string PhoneNumber { get; set; } = null!;

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        public virtual ICollection<Product> SellerProduct { get; set; } = new HashSet<Product>();
    }
}