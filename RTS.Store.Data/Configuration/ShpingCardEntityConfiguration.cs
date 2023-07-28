namespace RTS.Store.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RTS.Store.Data.Models;

    public class ShpingCardEntityConfiguration : IEntityTypeConfiguration<ShopingCard>
    {
        public void Configure(EntityTypeBuilder<ShopingCard> builder)
        {
            builder.HasOne(p => p.Payment)
                .WithMany(p => p.ShopingCards)
                .HasForeignKey(p=>p.PaymentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
