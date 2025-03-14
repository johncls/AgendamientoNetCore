using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Client;

namespace Application.Clients
{
    internal sealed class CreatedClientCommandHandler : ICommandHandler<CreatedClientCommand, Guid>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreatedClientCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Guid>> Handle(CreatedClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByClientAsync(request.identification, cancellationToken);

            if (client is null)
            {
                try
                {
                    var clientData = Client.Create(request.identification, request.name, request.lastName, request.phone, request.email, request.address, request.city, request.state, request.country);

                    _clientRepository.Add(clientData);

                    await _unitOfWork.SaveChangedAsync(cancellationToken);

                    return clientData.Id;


                }
                catch (Exception ex)
                {

                    return Result.Failure<Guid>(Error.None);
                }
            }

             return Result.Failure<Guid>(Error.Client);

        }

    }
}