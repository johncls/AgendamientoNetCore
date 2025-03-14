
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
                Id  = request.Id,
                Name = request.Name,
                Price = request.Price,
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