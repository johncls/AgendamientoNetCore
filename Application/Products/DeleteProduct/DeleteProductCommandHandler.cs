using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Product;

namespace Application.Products.DeleteProduct
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.DeleteProduct(request.productId, cancellationToken);

            if (result)
                return result;

            return Result.Failure<bool>(Error.None);
        }
    }
}