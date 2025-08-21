using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Shifts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agendamiento.Api.Controllers.Shifts
{
    [ApiController]
    [Route("api/shifts")]
    public class ShiftsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<ShiftsController> _logger;

        public ShiftsController(ISender sender, ILogger<ShiftsController> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateShifts([FromBody] CreatedShiftsCommand shift)
        {
            _logger.LogInformation("Created shift request: {Shift}", shift);

            var result = await _sender.Send(shift);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest("Error en la creación del turno");
        }

    }
}