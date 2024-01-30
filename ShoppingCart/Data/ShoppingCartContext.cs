using ShoppingCart.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ShoppingCart.Data
{
    public class ShoppingCartContext : IdentityDbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
            : base(options)

        { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Company> Company { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Models.Category { CategoryId = 1, Name = "Comedy", DisplayOrder = 1 },
                new Models.Category { CategoryId = 2, Name = "Action", DisplayOrder = 2 },
                new Models.Category { CategoryId = 3, Name = "Fiction", DisplayOrder = 3 });

            modelBuilder.Entity<Product>().HasData(
                new Models.Product
                {
                    Id = 1,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Description = "believed to be one of the most influential authors to have ever existed, famously published only a single novel",
                    ISBN = "SWV0001",
                    //ListPrice = 99,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Models.Product
                {
                    Id = 2,
                    Title = "The Great Gatsby",
                    Author = "Nick Carraway",
                    Description = "is distinguished as one of the greatest texts for introducing students to the art of reading literature critically ",
                    ISBN = "SWV00078",
                    //ListPrice = 100,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Models.Product
                {
                    Id = 3,
                    Title = "One Hundred Years of Solitude",
                    Author = "Gabriel García Márquez",
                    Description = "The novel tells the story of seven generations of the Buendía family and follows the establishment of their town",
                    ISBN = "SWV0002",
                    //ListPrice = 101,
                    CategoryId = 1,
                    ImageUrl = ""
                });
            modelBuilder.Entity<State>().HasData(
              new Models.State { StateId = 1, StateName = "Texas", StateCode = "TX" },
              new Models.State { StateId = 2, StateName = "Ohio", StateCode = "OH" },
              new Models.State { StateId = 3, StateName = "North Carolina", StateCode = "NC" },
              new Models.State { StateId = 4, StateName = "Georgia", StateCode = "GA" },
              new Models.State { StateId = 5, StateName = "Delaware", StateCode = "DC" }
              );
            modelBuilder.Entity<City>().HasData(
                new Models.City { CityId = 1, CityName = "Sugar Land", StateId = 1 },
                new Models.City { CityId = 2, CityName = "Houston", StateId = 1 },
                new Models.City { CityId = 3, CityName = "Columbus", StateId = 2 },
                new Models.City { CityId = 4, CityName = "Dublin", StateId = 2 },
                new Models.City { CityId = 7, CityName = "Cary", StateId = 3 },
                new Models.City { CityId = 8, CityName = "WinstonSalem", StateId = 3 },
                new Models.City { CityId = 9, CityName = "Kennesaw", StateId = 4 },
                new Models.City { CityId = 10, CityName = "Rosswell", StateId = 4 },
                new Models.City { CityId = 11, CityName = "Wilmington", StateId = 5 }

                );
        }
    }
}
