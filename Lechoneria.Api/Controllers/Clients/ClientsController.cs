using Application.Clients;
using Application.Clients.DeleteClient;
using Application.Clients.GetClient;
using Application.Clients.UpdateClient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lechoneria.Api.Controllers.Clients
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(ISender sender, ILogger<ClientsController> logger)
        {
            _sender = sender;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetClients(Guid clientId, CancellationToken cancellationToken)
        {
            var query = new GetClientQuery(clientId);
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedClientCommand client)
        {
            _logger.LogInformation("Created  request :", client);

            var result = await _sender.Send(client);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Error en la creación de cliente");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedClientCommand client)
        {
            _logger.LogInformation("Updated  request :", client);

            var result = await _sender.Send(client);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Error en la actualización de cliente");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClients(Guid id, CancellationToken cancellationToken )
        {
             _logger.LogInformation("Deleted  request :", id);

             var result = await _sender.Send(new DeleteClientCommand(id));
             if (result != null){
                 return Ok(result);
             }

             return BadRequest("Error en la eliminación del cliente");
        }
    }
}