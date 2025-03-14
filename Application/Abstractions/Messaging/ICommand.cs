using Domain.Abstractions;
using MediatR;

namespace Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>, IBaseCommand
    {
    }
    /// <summary>
    /// interface si se necesita para devolver un valor
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {

    }
    /// <summary>
    /// Constrainst para verificacion de interface
    /// </summary>
    public interface IBaseCommand
    {
    }
}