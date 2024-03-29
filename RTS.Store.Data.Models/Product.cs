﻿namespace RTS.Store.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static RTS.Store.Common.EntityValidationConstants.Product;

    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(ProductDescriptionMaxLength, MinimumLength =ProductDescriptionMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        [MinLength(ProductDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageurlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public decimal? Price { get; set; }

        public decimal? QuantityInStock { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public Guid SellerId { get; set; } 

        public Seller Seller { get; set; } = null!;

        public string? BuyerId { get; set; }

        [ForeignKey("BuyerId")]
        public virtual ApplicationUser? Buyer { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new HashSet<ProductOrder>();  

        //public Guid? ShopingCardId { get; set; }
        //
        //public ShopingCard? ShopingCard { get; set; }




    }
}
