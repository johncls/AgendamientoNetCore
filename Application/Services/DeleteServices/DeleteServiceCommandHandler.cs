using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Services;

namespace Application.Services
{
    internal sealed class DeleteServiceCommandHandler : ICommandHandler<DeleteServiceCommand, bool>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteServiceCommandHandler(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var result = await _serviceRepository.DeleteService(request.Id, cancellationToken);

            if (result)
            {
                await _unitOfWork.SaveChangedAsync(cancellationToken);
                return true;
            }

            return Result.Failure<bool>(new Error("Service.NotFound", "El servicio no fue encontrado"));
        }
    }
}