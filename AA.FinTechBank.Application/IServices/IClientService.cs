using AA.FinTechBank.Common.Utils;
using AA.FinTechBank.Domain.Dto;
using AA.FinTechBank.Domain.Entities;

namespace AA.FinTechBank.Application.IServices
{
    public interface IClientService
    {
        Task<ApiResponse<IEnumerable<EClient>>> GetAllAsync();
        Task<ApiResponse<EClient>> GetByIdAsync(Guid clientId);
        Task<ApiResponse<string>> DeleteAsync(Guid clientId);
        Task<ApiResponse<string>> UpdateAsync(Guid clientId,EClient client);
        Task<ApiResponse<CreateClientDto>> CreateAsync(EClient client);

    }
}
