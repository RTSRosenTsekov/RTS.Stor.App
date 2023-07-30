namespace RTS.Store.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
           // this.Id = Guid.NewGuid();
            this.ShopingCards = new HashSet<ShopingCard>();
            this.BuyProduct = new HashSet<Product>();
        }

        [Required]
        [MaxLength(10)]
        [MinLength(3)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(15)]
        [MinLength(3)]
        public string LastName { get; set; } = null!;

        [MaxLength(50)]
        [MinLength(10)]
        public string? Address { get; set; }

        public virtual ICollection<ShopingCard> ShopingCards { get; set; }

        public  ICollection<Product> BuyProduct { get; set; }

        public ICollection<Seller> Sellers { get; set; }

    }
}