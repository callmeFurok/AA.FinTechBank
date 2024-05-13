using AA.FinTechBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AA.FinTechBank.Infrastructure.DbContextApp
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

       public DbSet<EClient> Clients { get; set; }
        public DbSet<EApplicationUser> Users { get; set; }

    }
}
