using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        //step 1: pass the connection string
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }//Categories is the table name and this line will automatically create a table using the migration command

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//adding records to the table category
            modelBuilder.Entity<Category>().HasData(//The HasData method is used to define the data to be seeded.
                new Category { ID = 1, Name = "Action", DisplayOrder = 1},
                new Category { ID = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { ID = 3, Name = "History", DisplayOrder = 3 }

                );
        }
    }
}
