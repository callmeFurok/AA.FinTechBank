using AA.FinTechBank.Common.Utils;
using AA.FinTechBank.Domain.Entities;

namespace AA.FinTechBank.Application.IServices
{
    public interface IClientService
    {
        Task<ApiResponse<IEnumerable<EClient>>> GetAllAsync();
        Task<ApiResponse<EClient>> GetByIdAsync(Guid clientId);
        Task<ApiResponse<EClient>> DeleteAsync(Guid clientId);
        Task<ApiResponse<EClient>> UpdateAsync(Guid clientId,EClient client);
        Task<ApiResponse<EClient>> CreateAsync(EClient client);

    }
}
