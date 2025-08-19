using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Invoices;
using Application.Invoices.GetInvoice;
using Application.Invoices.UpdateInvoice;
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
        [HttpGet]
        public async Task<IActionResult> GetInvoice(Guid invoiceId, string? DocName, DateTime? CreatedDate, Guid? ClientId, CancellationToken cancellationToken)
        {
            var query = new GetInvoiceQuery(invoiceId, DocName, CreatedDate, ClientId);
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedInvoiceCommand invoice)
        {
            _logger.LogInformation("Created  request :", invoice);

            var result = await _sender.Send(invoice);
            if (result != null && result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest("Error en la creación de la factura");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateInvoiceCommand invoice)
        {
            _logger.LogInformation("Update request :", invoice);

            var result = await _sender.Send(invoice);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Error en la actualización de la factura");
        }
    }
}