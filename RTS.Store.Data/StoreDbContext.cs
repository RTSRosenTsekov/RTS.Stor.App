namespace RTS.Store.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using RTS.Store.Data.Models;
    using Microsoft.AspNetCore.Identity;
   

    public class StoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Seller> Sellers { get; set; } = null!;

        public DbSet<ShopingCard> ShopingCards { get; set; } = null!;

        public DbSet<Payment> Payments { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<ProductOrder> ProductOrders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Assembly configAssembly = Assembly.GetAssembly(typeof(StoreDbContext)) ?? Assembly.GetExecutingAssembly();
            //builder.ApplyConfigurationsFromAssembly(configAssembly);

            builder.Entity<ApplicationUser>()
                .Property(p => p.FirstName)
                .HasDefaultValue("Бай");
            builder.Entity<ApplicationUser>()
                .Property(p => p.LastName)
                .HasDefaultValue("Иван");

                       
            builder.Entity<Product>()
                .Property(p => p.CreatedOn)
               .HasDefaultValueSql("GETDATE()");

            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
                .HasOne(p => p.Seller)
                .WithMany(p => p.SellerProduct)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
                .HasOne(p=>p.Buyer)
                .WithMany(p => p.BuyProduct)
                .HasForeignKey(p => p.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ShopingCard>()
                   .HasOne(p => p.Payment)
                   .WithMany(p => p.ShopingCards)
                   .HasForeignKey(p => p.PaymentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ShopingCard>()
                .HasOne(p=>p.User)
                .WithMany(p => p.ShopingCards)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ShopingCard>()
                .HasMany(o=>o.Order)
                .WithOne(o=>o.ShopingCard)
                .HasForeignKey(o=>o.ShopingCardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProductOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId });

            builder.Entity<ProductOrder>()
                .HasOne(o => o.Product)
                .WithMany(po=>po.ProductOrders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(o => o.ProductId);


            builder.Entity<ProductOrder>()
                .HasOne(p => p.Order)
                .WithMany(po => po.ProductOrders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(o => o.OrderId);

           ///builder.Entity<ProductOrder>()
           //    .HasOne(p => p.Order)
           //    .WithMany(po => po.ProductOrders)
           //    .OnDelete(DeleteBehavior.Restrict)
           //    .HasForeignKey(o => o.OrderId);

            builder.Entity<ApplicationUser>().HasData(this.GenerateUser());
            builder.Entity<Seller>().HasData(this.GenerateSeller());
            builder.Entity<Category>().HasData(this.GenerateCategory());
            builder.Entity<Product>().HasData(this.GenerateProducts());

            base.OnModelCreating(builder);
        }

        private ApplicationUser[] GenerateUser()
        {
            ICollection<ApplicationUser> applicationUsers = new HashSet<ApplicationUser>();
       
            ApplicationUser user;
            
            ApplicationUser user2;
            string password = "123456";
            var hasherPassword = new PasswordHasher<ApplicationUser>();
            user = new ApplicationUser()
            {
                Id = "ddcb42c8-a394-45cd-82ae-b1e71d5c693e",
                UserName = "rosenSeller@abv.bg",
                NormalizedUserName = "ROSENSELLER@ABV.BG",
                Email = "rosenSeller@abv.bg",
                NormalizedEmail = "ROSENSELLER@ABV.BG",
                //SecurityStamp=Guid.NewGuid().ToString("D"),
       
            };
       
            var hashed = hasherPassword.HashPassword(user, password);
            user.PasswordHash = hashed;
       
            applicationUsers.Add(user);
                        
            user2 = new ApplicationUser()
            {
                Id = "3c11c7aa-d85a-462a-931e-adcc203d21f4",
                UserName = "yavorSeller@abv.bg",
                NormalizedUserName = "YAVORSELLER@ABV.BG",
                Email = "yavorSeller@abv.bg",
                NormalizedEmail = "YAVORSELLER@ABV.BG",
                // SecurityStamp = Guid.NewGuid().ToString("Y"),
            };
       
            hashed = hasherPassword.HashPassword(user2, password);
            user2.PasswordHash = hashed;
       
            applicationUsers.Add(user2);
       
            return applicationUsers.ToArray();
        }
       
        private Category[] GenerateCategory()
        {
            ICollection<Category> categories = new HashSet<Category>();
       
            Category category;
            Category category2;
            Category category3;
       
            category = new Category()
            {
                Id = 1,
                Name = "Car"
            };
       
            categories.Add(category);
       
            category2 = new Category()
            {
                Id = 2,
                Name = "Food"
            };
       
            categories.Add(category2);
       
            category3 = new Category()
            {
                Id = 3,
                Name = "For home"
            };
            categories.Add(category3);
       
            return categories.ToArray();
        }
       
        private Product[] GenerateProducts()
        {
            ICollection<Product> products = new HashSet<Product>();
       
            Product product;
            Product product1;
            Product product2;
       
            product = new Product()
            {
                Id = Guid.Parse("570c58a9-7d93-4b1b-a1e9-a778f94d9d06"),
                Name = "BMW 530D",
                Description = "BMW 530d e39, 193к.с Година: 2002 , Цвят:Синя , Екстри:Подгрев на /редните/ седалки , Мултиволан, Темпомат, ",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?//=tbn:ANd9GcTqi0u80NkjoORAddgNXSmZM-2qx_vlwnaJbg&usqp=CAU",
                Price = 10000.00M,
                QuantityInStock = 1,
                //CreatedOn = DateTime.Now,
                IsActive = true,
                CategoryId = 1,
                SellerId = Guid.Parse("d111a3be-2961-4d6f-8a00-9fae1ecf9cd7")
            };
       
            products.Add(product);
       
            product1 = new Product()
            {
                Id = Guid.Parse("5211c8cd-bc4c-41c6-aa72-bca634315dc9"),
                Name = "Прасе",
                Description = "Прасето е от породата Landrace и е 150 кг.Цена за килограм е 10 лв..",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?//=tbn:ANd9GcTQIRWQanNZMfTV3IsSgZpNuq6VulEr0cP1iQ&usqp=CAU",
                Price = 1500.00M,
                QuantityInStock = 5,
                // CreatedOn = DateTime.Now,
                IsActive = true,
                CategoryId = 2,
                SellerId = Guid.Parse("7b427f6a-a62a-44c5-948f-6d78f524cebe")
            };
       
            products.Add(product1);
       
            product2 = new Product()
            {
                Id = Guid.Parse("47355a7a-89a1-47b9-b5c5-35329a297a48"),
                Name = "Диван",
                Description = "Дивана е дълъг 245 см., лежанката е 175 см.",
                ImageUrl = "https://ivveks.com/wp-content/uploads/2021/09/bri-1-scaled.jpg",
                Price = 2000.00M,
                QuantityInStock = 1,
                // CreatedOn = DateTime.Now,
                IsActive = true,
                CategoryId = 3,
                SellerId = Guid.Parse("7b427f6a-a62a-44c5-948f-6d78f524cebe")
       
            };
       
            products.Add(product2);
       
            return products.ToArray();
        }
       
        private Seller[] GenerateSeller()
        {
            ICollection<Seller> sellers = new HashSet<Seller>();
       
            Seller seller;
            Seller seller2;
       
            seller = new Seller()
            {
                Id= Guid.Parse("7b427f6a-a62a-44c5-948f-6d78f524cebe"),
                PhoneNumber="0899495555",
                UserId= "3c11c7aa-d85a-462a-931e-adcc203d21f4"

            };
       
            sellers.Add(seller);
       
            seller2 = new Seller()
            {
                Id= Guid.Parse("d111a3be-2961-4d6f-8a00-9fae1ecf9cd7"),
                PhoneNumber="0897556677",
                UserId = "ddcb42c8-a394-45cd-82ae-b1e71d5c693e"
            };
       
            sellers.Add(seller2);
       
            return sellers.ToArray();   
        }
    }
}