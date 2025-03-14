using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Products;
using Application.Products.DeleteProduct;
using Application.Products.GetProducts;
using Application.Products.UpdateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lechoneria.Api.Controllers.Products
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ISender sender, ILogger<ProductsController> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedProductCommand product)
        {
            _logger.LogInformation("Created  request :", product);

            var result = await _sender.Send(product);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Error en la creación de producto");
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct(Guid productId, CancellationToken cancellationToken)
        {
            var query = new GetProductQuery(productId);
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : NotFound();

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedProductCommand product)
        {
            _logger.LogInformation("Updated  request :", product);

            var result = await _sender.Send(product);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Error en la actualización de producto");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleted  request :", id);

            var result = await _sender.Send(new DeleteProductCommand(id));
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Error en la eliminación del producto");
        }
    }
}