namespace RTS.Store.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RTS.Store.Data.Models;

    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(p=>p.Category)
                .WithMany(p=>p.Products)
                .HasForeignKey(p=>p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p=>p.Seller)
                .WithMany(p=>p.SellerProduct)
                .HasForeignKey(p=>p.SellerId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasData(this.GenerateProducts());
        }

        private Product[] GenerateProducts()
        {
            ICollection<Product> products = new HashSet<Product>();

            Product product;
            Product product1;
            Product product2;

            product = new Product()
            {
                Id= Guid.Parse("570c58a9-7d93-4b1b-a1e9-a778f94d9d06"),
                Name = "BMW 530D",
                Description = "BMW 530d e39, 193к.с Година: 2002 , Цвят:Синя , Екстри:Подгрев на предните седалки , Мултиволан, Темпомат, ",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTqi0u80NkjoORAddgNXSmZM-2qx_vlwnaJbg&usqp=CAU",
                Price = 10000.00M,
                QuantityInStock= 1,
                //CreatedOn = DateTime.Now,
                IsActive = true,
                CategoryId = 1,
                SellerId = Guid.Parse("ddcb42c8-a394-45cd-82ae-b1e71d5c693e"),
            };

            products.Add(product);

            product1 = new Product()
            {
                Id= Guid.Parse("5211c8cd-bc4c-41c6-aa72-bca634315dc9"),
                Name = "Прасе",
                Description = "Прасето е от породата Landrace и е 150 кг.Цена за килограм е 10 лв..",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTQIRWQanNZMfTV3IsSgZpNuq6VulEr0cP1iQ&usqp=CAU",
                Price = 1500.00M,
                QuantityInStock= 5,
               // CreatedOn = DateTime.Now,
                IsActive = true,
                CategoryId = 2,
                SellerId = Guid.Parse("d111a3be-2961-4d6f-8a00-9fae1ecf9cd7")
            };

            products.Add(product1);

            product2 = new Product()
            {
                Id= Guid.Parse("47355a7a-89a1-47b9-b5c5-35329a297a48"),
                Name = "Диван",
                Description = "Дивана е дълъг 245 см., лежанката е 175 см.",
                ImageUrl = "https://ivveks.com/wp-content/uploads/2021/09/bri-1-scaled.jpg",
                Price = 2000.00M,
                QuantityInStock= 1,
               // CreatedOn = DateTime.Now,
                IsActive = true,
                CategoryId = 3,
                SellerId = Guid.Parse("3c11c7aa-d85a-462a-931e-adcc203d21f4")

            };

            products.Add(product2);

            return products.ToArray();
        }
    }
}
