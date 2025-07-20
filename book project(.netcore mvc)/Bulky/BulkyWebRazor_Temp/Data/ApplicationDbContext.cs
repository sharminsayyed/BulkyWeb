using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore; // this is a nuget package 
using BulkyWebRazor_Temp.Models;
namespace BulkyWebRazor_Temp.Data
{
    public class ApplicationDbContext:DbContext
    {
        // basic configuration of entity framework core
        // pass th connection string 
        //DbContextOptions is a configuration object that tells EF Core how to connect to the database
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        // create a table 
        public DbSet<Category> Categories { get; set; }
        // add-migration AddCategoriesTableToDb 

        // to add records to the category table 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Comedy", DisplayOrder = 3 },
                new Category { Id = 3, Name = "SciFi", DisplayOrder = 2 }
                );
        }

    }
}

