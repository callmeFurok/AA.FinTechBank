﻿using AA.FinTechBank.Application.IServices;
using AA.FinTechBank.Common.Utils;
using AA.FinTechBank.Domain.Dto;
using AA.FinTechBank.Domain.Entities;
using AA.FinTechBank.Domain.IRepositories;
using AutoMapper;

namespace AA.FinTechBank.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository,IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CreateClientDto>> CreateAsync(EClient client)
        {
            try
            {
                var clientToCreate = _mapper.Map<EClient>(client);
                await _clientRepository.CreateAsync(clientToCreate);
                var apiResponse = new ApiResponse<CreateClientDto>()
                {
                    Success = true,
                    Message = "Usuario Creado",

                };

                return apiResponse;

            }
            catch (Exception e)
            {

                var apiResponse = new ApiResponse<CreateClientDto>()
                {
                    Success = false,
                    Message = "Error al crear el usuario",
                    Errors = new List<string>() { e.Message }

                };

                return apiResponse;
            }

        }

        public async Task<ApiResponse<string>> DeleteAsync(Guid clientId)
        {
            try
            {

                await _clientRepository.DeleteAsync(clientId);
                var apiResponse = new ApiResponse<string>()
                {
                    Success = true,
                    Message = "Usuario eliminado",

                };

                return apiResponse;

            }
            catch (Exception e)
            {

                var apiResponse = new ApiResponse<string>()
                {
                    Success = false,
                    Message = "Error al eliminar el usuario",
                    Errors = new List<string>() { e.Message }

                };

                return apiResponse;
            }
        }

        public async Task<ApiResponse<IEnumerable<EClient>>> GetAllAsync()
        {

            try
            {

                var allClients = await _clientRepository.GetAllAsync() ?? throw new Exception();

                var apiResponse = new ApiResponse<IEnumerable<EClient>>()
                {
                    Success = true,
                    Message = "Lista de todos los clientes",
                    Data = allClients


                };

                return apiResponse;

            }
            catch (Exception e)
            {

                var apiResponse = new ApiResponse<IEnumerable<EClient>>()
                {
                    Success = false,
                    Message = "Error al listar todos el los clientes",
                    Errors = new List<string>() { e.Message }

                };

                return apiResponse;
            }

        }

        public async Task<ApiResponse<EClient>> GetByIdAsync(Guid clientId)
        {
            try
            {
                var clientById = await _clientRepository.GetByIdAsync(clientId) ?? throw new Exception("Error el cliente no existe");
                var apiResponse = new ApiResponse<EClient>()
                {
                    Success = true,
                    Message = "Datos del usuario " + clientId,
                    Data = clientById

                };

                return apiResponse;

            }
            catch (Exception e)
            {

                var apiResponse = new ApiResponse<EClient>()
                {
                    Success = false,
                    Message = "Error buscar el usuario",
                    Errors = new List<string>() { e.Message }

                };

                return apiResponse;
            }

        }

        public async Task<ApiResponse<string>> UpdateAsync(Guid clientId, EClient client)
        {
            try
            {

                //validate if a client exists
                var clientExists = await _clientRepository.GetByIdAsync(clientId) ?? throw new Exception("No existe el cliente");

                await _clientRepository.UpdateAsync(clientId, client);
                var apiResponse = new ApiResponse<string>()
                {
                    Success = true,
                    Message = "Usuario actualizado",

                };

                return apiResponse;

            }
            catch (Exception e)
            {

                var apiResponse = new ApiResponse<string>()
                {
                    Success = false,
                    Message = "Error al actualizar el usuario",
                    Errors = new List<string>() { e.Message }

                };

                return apiResponse;
            }
        }
    }
}
