
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Product;

namespace Application.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdatedProductCommand, Product>
    {
         private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Product>> Handle(UpdatedProductCommand request, CancellationToken cancellationToken)
        {
            Product productData = new (){
                Id = request.Id,
                Name = request.Name,
                CodeProduct = request.CodeProduct,
                Price = request.Price,
                Amount = request.Amount ?? 0,
                UnitOfMeasurement = request.UnitOfMeasurement ?? string.Empty,
                DateCreated = request.DataCreated,
                
            };

            try{
                var result = await _productRepository.UpdateProduct(productData, request.Id, cancellationToken);

                if (result)
                {
                    return productData;
                }

                return Result.Failure<Product>(Error.None);
            }
            catch
            {
                return Result.Failure<Product>(Error.None);
            }
        }
    }
}