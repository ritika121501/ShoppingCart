using ShoppingCart.Models;
using Microsoft.EntityFrameworkCore;


namespace ShoppingCart.Data
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options)
        { }
        public DbSet<Category> Category { get; set; }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Models.Category { CategoryId = 3, Name = "Comedy", DisplayOrder = 1 },
                new Models.Category { CategoryId = 2, Name = "Action", DisplayOrder = 2 },
                new Models.Category { CategoryId = 1, Name = "Fiction", DisplayOrder = 3 });

            modelBuilder.Entity<Product>().HasData(
              new Models.Product
              {
                  Id = 1,
                  Title = "Little Women",
                  Author = "Louisa May Alcott",
                  Description = "Generations of readers young and old, male and female, " +
                               "have fallen in love with the March sisters of Louisa May Alcott’s most popular and enduring novel, Little Women",
                  ISBN = "SW001",
                  ListPrice = 99
              },

             new Models.Product
             {
              Id = 2,
              Title = "One Hot Italian Summer",
              Author = "Karina Halle",
              Description = "After the death of her best friend and writing partner, " +
                            "Grace Harper is struggling both with grief, and with her next novel," +
                            " the first one she’ll have to write alone",
              ISBN = "SW002",
              ListPrice = 89
             },

             new Models.Product
             {
              Id = 3,
              Title = "The Thirteenth Tale",
              Author = "Diane Setterfield",
              Description = "Reclusive author Vida Winter," +
                             " famous for her collection of twelve enchanting stories," +
                            " has spent the past six decades penning a series of alternate lives for herself. ",
              ISBN = "SW003",
              ListPrice = 109

             });



        }
    }
}
