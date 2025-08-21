using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Services;

namespace Application.Services.GetAllServices
{
    public class GetAllServiceQueryHandler : IQueryHandler<GetAllServicesQuery, List<ServiceResponse>>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetAllServiceQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<Result<List<ServiceResponse>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _serviceRepository.GetAllAsync(cancellationToken);

           return services.Select(service => new ServiceResponse(
                service.Id,
                service.NameService,
                service.OpeningHour,
                service.ClosingHour,
                service.Duration
            )).ToList();
        }
    }

    
}