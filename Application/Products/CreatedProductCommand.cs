using Application.Abstractions.Messaging;

namespace Application.Products
{
    /// <summary>
    /// Creacion cliente
    /// </summary>
    /// <param name="name">nombre</param>
    /// <param name="price">precio</param>
    /// <param name="dateCreated">fecha de creación</param>
    public record CreatedProductCommand(
            string name,
            decimal price,
            int Amount,
            string UnitOfMeasurement,
            DateTime dateCreated

        ) : ICommand<Guid>;
}