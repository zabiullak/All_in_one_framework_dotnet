using _BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace _BookStore.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Non-fiction", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Biography", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Fiction", DisplayOrder = 3 },
                new Category { Id = 4, Name = "History", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Spirituality", DisplayOrder = 5 },
                new Category { Id = 6, Name = "Novel", DisplayOrder = 6 },
                new Category { Id = 7, Name = "Self-help Book", DisplayOrder = 7 });
        }
    }
}
