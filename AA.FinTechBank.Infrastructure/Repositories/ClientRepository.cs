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
        public async Task CreateAsync(EClient client)
        {
            await _context.Clients.AddAsync(client);
            await SaveAsync();
        }

        public async Task DeleteAsync(Guid clientId)
        {
            EClient clientToDelete = await GetByIdAsync(clientId);

            _context.Clients.Remove(clientToDelete);

            await SaveAsync();
        }

        public async Task<IEnumerable<EClient>> GetAllAsync()
        {
            List<EClient> clientList = await _context.Clients.ToListAsync();

            return clientList;
        }

        public async Task<EClient> GetByIdAsync(Guid clientId)
        {
            EClient clientById = await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == clientId);

            return clientById;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid clientId, EClient client)
        {
            var clientToUpdate = await GetByIdAsync(clientId);
            _context.Clients.Entry(clientToUpdate).State = EntityState.Detached;
           _context.Clients.Update(client);
            await SaveAsync();
        }
    }
}
