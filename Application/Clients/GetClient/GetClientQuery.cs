using Application.Abstractions.Messaging;

namespace Application.Clients.GetClient
{
    public sealed record GetClientQuery(Guid clientId) : IQuery<ClientResponse>;
}