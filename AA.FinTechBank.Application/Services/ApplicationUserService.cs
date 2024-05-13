using AA.FinTechBank.Application.IServices;
using AA.FinTechBank.Common.Utils;
using AA.FinTechBank.Domain.Dto;
using AA.FinTechBank.Domain.Entities;
using AA.FinTechBank.Domain.IRepositories;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace AA.FinTechBank.Application.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ApplicationUserService(IApplicationUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        private bool VerifyPasswordHash(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
        public async Task<ApiResponse<UserTokenDto>> AuthenticateUserAsync(string username, string password)
        {
            try
            {
                var userExists = await _userRepository.SearchByUsernameAsync(username) ?? throw new Exception();

                if (!VerifyPasswordHash(password, userExists.PasswordHash))
                {
                    throw new Exception();
                }

                var createToken = new JwtTokenGenerator(_configuration).GenerateToken(username);

                var apiResponse = new ApiResponse<UserTokenDto>()
                {
                    Success = true,
                    Message = "Usuario autenticado",
                    Data = new UserTokenDto()
                    {
                        UserName = username,
                        Token = createToken
                    }

                };

                return apiResponse;

            }
            catch (Exception e)
            {

                var apiResponse = new ApiResponse<UserTokenDto>()
                {
                    Success = false,
                    Message = "Error al autenticarse",
                    Errors = new List<string>() { e.Message }


                };

                return apiResponse;
            }
        }

        public async Task<ApiResponse<CreateUserDto>> CreatUserAsync(CreateUserDto applicationUser)
        {
            try
            {

                var userMapp = _mapper.Map<EApplicationUser>(applicationUser);
                userMapp.PasswordHash = BCrypt.Net.BCrypt.HashPassword(applicationUser.Password);


                await _userRepository.CreateApplicationUserAsync(userMapp);

                var apiResponse = new ApiResponse<CreateUserDto>()
                {
                    Success = true,
                    Message = "Usuario creado",

                };

                return apiResponse;
            }
            catch (Exception e)
            {


                var apiResponse = new ApiResponse<CreateUserDto>()
                {
                    Success = false,
                    Message = "Error al crear usuario",
                    Errors= new List<string>() { e.Message }

                };

                return apiResponse;
            }
        }
    }
}
