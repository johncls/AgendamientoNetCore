using Domain.Abstractions;
using MediatR;

namespace Application.Abstractions.Messaging
{
    public interface IQuery<TReponse> : IRequest<Result<TReponse>>
    {
    }
}