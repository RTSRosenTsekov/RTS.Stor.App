namespace RTS.Store.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Payment
    {
        

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CardName { get; set; } = null!;

        [Required]
        [MaxLength()]
        public decimal NumberOfCard { get; set; }

        [Required]
        public string FullName { get; set; }=null!;

        [Required]
        public string EpiryDate { get; set; } = null!;

        [Required]
        public int CCV { get; set; }

        public virtual ICollection<ShopingCard> ShopingCards { get; set; }= new HashSet<ShopingCard>();
    }
}