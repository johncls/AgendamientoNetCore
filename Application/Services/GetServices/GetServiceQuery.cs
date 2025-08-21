using Application.Abstractions.Messaging;

namespace Application.Services
{
    public record GetServiceQuery(Guid Id) : IQuery<ServiceResponse>;

    public record GetAllServicesQuery : IQuery<List<ServiceResponse>>;
}