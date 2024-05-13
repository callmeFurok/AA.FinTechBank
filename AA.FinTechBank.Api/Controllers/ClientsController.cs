using AA.FinTechBank.Application.IServices;
using AA.FinTechBank.Common.Utils;
using AA.FinTechBank.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AA.FinTechBank.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ApiResponse<IEnumerable<EClient>>>> GetAllAsync()
        {
            var serviceResponse = await _clientService.GetAllAsync();
            if (serviceResponse.Success)
                return Ok(serviceResponse);

            return BadRequest(serviceResponse);
        }

        [HttpGet("{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult<ApiResponse<IEnumerable<EClient>>>> GetByIdAsync(Guid clientId)
        {
            var serviceResponse = await _clientService.GetByIdAsync(clientId);
            if (serviceResponse.Success)
                return Ok(serviceResponse);

            return BadRequest(serviceResponse);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ApiResponse<EClient>>> CreateAsync([FromBody] EClient client)
        {
            var serviceResponse = await _clientService.CreateAsync(client);
            if (serviceResponse.Success)

                return Ok(serviceResponse);

            return BadRequest(serviceResponse);

        }

        [HttpPut("{clientId}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ApiResponse<EClient>>> UpdateAsync(Guid clientId, [FromBody] EClient client)
        {
            var serviceResponse = await _clientService.UpdateAsync(clientId,client);
            if (serviceResponse.Success)

                return Ok(serviceResponse);

            return BadRequest(serviceResponse);

        }

        [HttpDelete("{clientId}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]



        public async Task<ActionResult<ApiResponse<EClient>>> DeleteAsync(Guid clientId)
        {
            var serviceResponse = await _clientService.DeleteAsync(clientId);
            if (serviceResponse.Success)

                return Ok(serviceResponse);

            return BadRequest(serviceResponse);

        }



    }
}
