using AA.FinTechBank.Domain.Entities;
using AA.FinTechBank.Domain.IRepositories;
using AA.FinTechBank.Infrastructure.DbContextApp;
using Microsoft.EntityFrameworkCore;

namespace AA.FinTechBank.Infrastructure.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

      
        public async Task CreateApplicationUserAsync(EApplicationUser applicationUser)
        {
            await _context.Users.AddAsync(applicationUser);
            await _context.SaveChangesAsync();
        }

        public async Task<EApplicationUser> SearchByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        }
    }
}
