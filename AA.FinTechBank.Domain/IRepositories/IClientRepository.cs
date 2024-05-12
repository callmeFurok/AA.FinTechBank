using AA.FinTechBank.Domain.Entities;

namespace AA.FinTechBank.Domain.IRepositories
{
    public interface IClientRepository
    {
        Task<List<EClient>> GetAllAsync(string id);
        Task<EClient> GetByIdAsync(Guid clientId);
        Task DeleteAsync(int id);
        Task<EClient> UpdateAsync(EClient client);
        Task CreateAsync(EClient client);

    }
}
