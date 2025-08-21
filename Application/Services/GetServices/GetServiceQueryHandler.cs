using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Services;

namespace Application.Services
{
    internal sealed class GetServiceQueryHandler : IQueryHandler<GetServiceQuery, ServiceResponse>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetServiceQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Result<ServiceResponse>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.Id, cancellationToken);

            if (service is null)
            {
                return Result.Failure<ServiceResponse>(new Error("Service.NotFound", "El servicio no fue encontrado"));
            }

            var response = new ServiceResponse(
                service.Id,
                service.NameService,
                service.OpeningHour,
                service.ClosingHour,
                service.Duration
            );

            return response;
        }
    }
}