using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Product;


namespace Application.Products
{
    internal sealed class CreatedProductCommandHandler : ICommandHandler<CreatedProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreatedProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Guid>> Handle(CreatedProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByNameProductAsync(request.name, cancellationToken);

            if (product is null)
            {
                try
                {

                    var productData = Product.Created(request.name, request.price, request.Amount, request.UnitOfMeasurement, DateTime.UtcNow);

                    _productRepository.Add(productData);

                    await _unitOfWork.SaveChangedAsync(cancellationToken);

                    return productData.Id;


                }
                catch 
                {

                    return Result.Failure<Guid>(Error.Product);
                }
            }

             return Result.Failure<Guid>(Error.Product);

        }

    }
}