using AA.FinTechBank.Application.IServices;
using AA.FinTechBank.Domain.Entities;
using AA.FinTechBank.Domain.IRepositories;

namespace AA.FinTechBank.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<bool> CreateAsync(EClient client)
        {
           
                var isCreatedClient = await _clientRepository.CreateAsync(client);
               return isCreatedClient;
            
           
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EClient>> GetAllAsync()
        {
            var allClients= _clientRepository.GetAllAsync();

            return allClients;
        }

        public Task<EClient> GetByIdAsync(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public Task<EClient> UpdateAsync(EClient client)
        {
            throw new NotImplementedException();
        }
    }
}
