using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Client;

namespace Application.Clients.DeleteClient
{
    public class DeleteClientCommandHandler : ICommandHandler<DeleteClientCommand, bool>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteClientCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }



        public async Task<Result<bool>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var result = await _clientRepository.DeleteClientAsync(request.clientId, cancellationToken);

            if ( result)
                return result;

               return Result.Failure<bool>(Error.None);
        }
    }
}