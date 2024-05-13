using AA.FinTechBank.Common.Utils;
using AA.FinTechBank.Domain.Dto;

namespace AA.FinTechBank.Application.IServices
{
    public interface IApplicationUserService
    {
        Task<ApiResponse<CreateUserDto>> CreatUserAsync(CreateUserDto applicationUser);
        Task<ApiResponse<UserTokenDto>> AuthenticateUserAsync(string username, string password);
    }
}
