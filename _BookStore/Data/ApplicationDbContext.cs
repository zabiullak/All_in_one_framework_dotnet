using Microsoft.EntityFrameworkCore;

namespace _BookStore.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option) 
        {
            
        }
    }
}
