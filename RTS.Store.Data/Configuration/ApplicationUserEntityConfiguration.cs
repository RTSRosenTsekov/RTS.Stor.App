namespace RTS.Store.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RTS.Store.Data.Models;
    using System;

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(f => f.FirstName).HasDefaultValue("Бай");
            builder.Property(f => f.LastName).HasDefaultValue("Иван");

            builder.HasData(this.GenerateUser());
        }

        private ApplicationUser[] GenerateUser()
        { 
            ICollection<ApplicationUser> applicationUsers = new HashSet<ApplicationUser>();

            ApplicationUser user;
            ApplicationUser user1;
            ApplicationUser user2;
            string password = "123456";
            var hasherPassword = new PasswordHasher<ApplicationUser>();
            user = new ApplicationUser()
            {
                Id = "ddcb42c8-a394-45cd-82ae-b1e71d5c693e",
                UserName="rosenSeller@abv.bg",
                NormalizedUserName="ROSENSELLER@ABV.BG",
                Email= "rosenSeller@abv.bg",
                NormalizedEmail= "ROSENSELLER@ABV.BG",
                //SecurityStamp=Guid.NewGuid().ToString("D"),
                
            };

            var hashed = hasherPassword.HashPassword(user,password);
            user.PasswordHash = hashed;

            applicationUsers.Add(user);

            user1 = new ApplicationUser()
            {
                Id = "d111a3be-2961-4d6f-8a00-9fae1ecf9cd7",
                UserName = "desiSeller@abv.bg",
                NormalizedUserName = "DESISELLER@ABV.BG",
                Email = "desiSeller@abv.bg",
                NormalizedEmail = "DESISELLER@ABV.BG",
                //SecurityStamp = Guid.NewGuid().ToString("R"),
            };

             hashed = hasherPassword.HashPassword(user1, password);
            user1.PasswordHash = hashed;

            applicationUsers.Add(user1);


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
    }
}
