
using Application.Abstractions.Messaging;

namespace Application.Services
{
    public record DeleteServiceCommand(Guid Id) : ICommand<bool>;
}