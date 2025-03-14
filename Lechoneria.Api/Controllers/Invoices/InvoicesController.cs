using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Invoices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lechoneria.Api.Controllers.Invoices
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoicesController: ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<InvoicesController> _logger;
        public InvoicesController(ISender sender, ILogger<InvoicesController> logger)
        {
            _sender = sender;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedInvoiceCommand invoice)
        {
            _logger.LogInformation("Created  request :", invoice);

            var result = await _sender.Send(invoice);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Error en la creación de la factura");
        }
    }
}