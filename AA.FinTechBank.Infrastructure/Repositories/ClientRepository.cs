using AA.FinTechBank.Domain.Entities;
using AA.FinTechBank.Domain.IRepositories;
using AA.FinTechBank.Infrastructure.DbContextApp;

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

        public Task<List<EClient>> GetAllAsync(string id)
        {
            throw new NotImplementedException();
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
