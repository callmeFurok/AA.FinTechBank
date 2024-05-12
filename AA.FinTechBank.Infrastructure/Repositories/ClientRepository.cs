using AA.FinTechBank.Domain.Entities;
using AA.FinTechBank.Domain.IRepositories;
using AA.FinTechBank.Infrastructure.DbContextApp;
using Microsoft.EntityFrameworkCore;

namespace AA.FinTechBank.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(EClient client)
        {
            await _context.Clients.AddAsync(client);
            return await SaveAsync();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EClient>> GetAllAsync()
        {
           List<EClient> clientList= await _context.Clients.ToListAsync();

            return clientList;
        }

        public Task<EClient> GetByIdAsync(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<EClient> UpdateAsync(EClient client)
        {
            throw new NotImplementedException();
        }
    }
}
