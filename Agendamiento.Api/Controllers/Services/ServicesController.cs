using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agendamiento.Api.Controllers.Services
{
    [ApiController]
    [Route("api/services")]
    public class ServicesController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<ServicesController> _logger;

        public ServicesController(ISender sender, ILogger<ServicesController> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedServiceCommand service)
        {
            _logger.LogInformation("Created service request: {Service}", service);
            var result = await _sender.Send(service);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest("Error en la creación del servicio");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetServiceQuery(id);
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices(CancellationToken cancellationToken)
        {
            var query = new GetAllServicesQuery();
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleted service request: {Id}", id);

            var result = await _sender.Send(new DeleteServiceCommand(id), cancellationToken);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return BadRequest("Error en la eliminación del servicio");
        }
    }
}