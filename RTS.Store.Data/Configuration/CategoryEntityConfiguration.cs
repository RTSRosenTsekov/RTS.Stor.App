namespace RTS.Store.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RTS.Store.Data.Models;
    using System;

    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategory());
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
    }
}
