using AA.FinTechBank.Domain.Entities;

namespace AA.FinTechBank.Domain.IRepositories
{
    public interface IClientRepository
    {
        Task<List<EClient>> GetAllAsync();
        Task<EClient> GetByIdAsync(Guid clientId);
        Task<bool> DeleteAsync(int id);
        Task<EClient> UpdateAsync(EClient client);
        Task<bool> CreateAsync(EClient client);

        Task<bool> SaveAsync();

    }
}
