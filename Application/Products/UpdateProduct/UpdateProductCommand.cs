using Application.Abstractions.Messaging;
using Domain.Product;

namespace Application.Products.UpdateProduct
{ 
    /// <summary>
    ///  Actualización de los productos
    /// </summary>
    /// <param name="id"> Guis de la tabla</param>
    /// <param name="Name"> nombre del producto</param>
    /// <param name="Price">precio del producto</param>
    /// <param name="DataCreated">Fecha creación</param>
    public record UpdatedProductCommand(
            Guid Id,
            string Name,
            decimal Price,
            DateTime DataCreated
        ) : ICommand<Product>;
}