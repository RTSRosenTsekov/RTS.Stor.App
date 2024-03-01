namespace RTS.Store.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public  class ProductOrder
    {
        [Key]
        public int OrderId { get; set; } 

        [ForeignKey("OrderId")]
        public Order Order { get; set; } = null!;

        [Key]
        public Guid ProductId { get; set; } 

        [ForeignKey("ProductId")]
        public Product Product { get; set; }= null!;
    }
}
