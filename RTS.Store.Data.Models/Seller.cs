namespace RTS.Store.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Seller
    {
        public Seller() 
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 7)]
        public string PhoneNumber { get; set; } = null!;

        public string UserId { get; set; } = null!;

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; } = null!;

        public virtual ICollection<Product> SellerProduct { get; set; } = new HashSet<Product>();
    }
}