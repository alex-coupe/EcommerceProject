using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasData(new Category { Id = 1, Name = "Men" },
                new Category { Id = 2, Name = "Women" },
                new Category { Id = 3, Name = "Kids" },
                new Category { Id = 4, Name = "Accessories" },
                new Category { Id = 5, Name = "Sales & Discounts" });

            builder.Entity<SubCategory>()
                .HasData(new SubCategory { Id = 1, Name = "Jeans" },
                new SubCategory { Id = 2, Name = "Blazers" },
                new SubCategory { Id = 3, Name = "Coats & Jackets" },
                new SubCategory { Id = 4, Name = "Suits" },
                new SubCategory { Id = 5, Name = "Underwear & Socks" },
                new SubCategory { Id = 6, Name = "Trainers & Shoes" },
                new SubCategory { Id = 7, Name = "Hoodies & Sweatshirts" },
                new SubCategory { Id = 8, Name = "Dresses & Skirts" },
                new SubCategory { Id = 9, Name = "Playsuits & Jumpsuits" },
                new SubCategory { Id = 10, Name = "Nightwear" },
                new SubCategory { Id = 11, Name = "Boots" },
                new SubCategory { Id = 12, Name = "Flip-Flops & Sandals" },
                new SubCategory { Id = 13, Name = "Babywear" },
                new SubCategory { Id = 14, Name = "Tracksuits" },
                new SubCategory { Id = 15, Name = "Shorts" },
                new SubCategory { Id = 16, Name = "Bags" },
                new SubCategory { Id = 17, Name = "Hats, Scarves & Gloves" },
                new SubCategory { Id = 18, Name = "Belts" },
                new SubCategory { Id = 19, Name = "Jewellery & Watches" },
                new SubCategory { Id = 20, Name = "Sunglasses" },
                new SubCategory { Id = 21, Name = "Wallets" });

 
               



        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }
    }
}
