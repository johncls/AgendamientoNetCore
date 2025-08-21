using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Services;

namespace Application.Services
{
    internal sealed class CreatedServiceCommandHandler : ICommandHandler<CreatedServiceCommand, Guid>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public CreatedServiceCommandHandler(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Result<Guid>> Handle(CreatedServiceCommand request, CancellationToken cancellationToken)
        {
            var existingService = await _serviceRepository.GetByNameServiceAsync(request.NameService, cancellationToken);

            if (existingService is not null)
            {
                return Result.Failure<Guid>(new Error("Service.AlreadyExists", "El servicio ya existe"));
            }

            try
            {
                if(request.OpeningHour >= request.ClosingHour)
                {
                    return Result.Failure<Guid>(new Error("Service.InvalidHours", "La hora de apertura debe ser anterior a la hora de cierre"));
                }
                
                var service = Service.Created(
                    request.TradeId,
                    request.NameService, 
                    request.OpeningHour, 
                    request.ClosingHour,
                    request.Duration);

                _serviceRepository.Add(service);

                await _unitOfWork.SaveChangedAsync(cancellationToken);

                return service.Id;
            }
            catch (Exception ex)
            {
                return Result.Failure<Guid>(new Error("Service.CreationFailed", ex.Message));
            }
        }
    }
}