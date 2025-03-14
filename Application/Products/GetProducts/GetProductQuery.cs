using Application.Abstractions.Messaging;

namespace Application.Products.GetProducts
{
    public sealed record GetProductQuery(Guid productId) : IQuery<ProductResponse>;
  
}