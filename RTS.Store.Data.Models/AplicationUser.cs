namespace RTS.Store.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class AplicationUser : IdentityUser<Guid>
    {
        public AplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.ShopingCards = new HashSet<ShopingCard>();
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
        public string Address { get; set; } = null!;

        public virtual ICollection<ShopingCard> ShopingCards { get; set; }

    }
}