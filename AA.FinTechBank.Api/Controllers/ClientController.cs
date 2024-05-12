using AA.FinTechBank.Application.IServices;
using AA.FinTechBank.Common.Utils;
using AA.FinTechBank.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AA.FinTechBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ApiResponse<List<EClient>>>> GetAllAsync()
        {
            try
            {
                var allClients = await _clientService.GetAllAsync();
                var apiResponse = new ApiResponse<List<EClient>>()
                {
                    Success = true,
                    Message = "Lista de todos los clientes",
                    Data = allClients,
                    Errors = new List<string>()

                };

                return Ok(apiResponse);

            }
            catch (Exception e)
            {
                var apiResponse = new ApiResponse<List<EClient>>()
                {
                    Success = false,
                    Message = "No se pudo recuperar",
                    Errors = new List<string>() { e.Message }

                };

                return BadRequest(apiResponse);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<bool>>> CreateAsync([FromBody] EClient client)
        {
            try
            {
                bool isCreated = await _clientService.CreateAsync(client);


                var apiResponse = new ApiResponse<bool>()
                {
                    Success = isCreated,
                    Message = "Usuario Creado",
                    Errors = new List<string>()

                };

                return Ok(apiResponse);

            }
            catch (Exception e)
            {

                var apiResponse = new ApiResponse<bool>()
                {
                    Success = false,
                    Message = "Error al crear el usuario",
                    Errors = new List<string>() { e.Message }

                };

                return BadRequest(apiResponse);
            }

        }

    }
}
