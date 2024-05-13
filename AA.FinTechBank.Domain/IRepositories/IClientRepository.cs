using AA.FinTechBank.Domain.Entities;

namespace AA.FinTechBank.Domain.IRepositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<EClient>> GetAllAsync();
        Task<EClient> GetByIdAsync(Guid clientId);
        Task DeleteAsync(Guid clientId);
        Task UpdateAsync(Guid clientId,EClient client);
        Task CreateAsync(EClient client);

        Task SaveAsync();

    }
}
