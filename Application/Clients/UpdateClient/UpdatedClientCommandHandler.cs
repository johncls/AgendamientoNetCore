using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Client;
using MediatR;

namespace Application.Clients.UpdateClient
{
    public class UpdatedClientCommandHandler : ICommandHandler<UpdatedClientCommand, Client>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdatedClientCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Client>> Handle(UpdatedClientCommand request, CancellationToken cancellationToken)
        {
            Client clientData = new Client()
            {
                Id = request.id,
                Name = request.name,
                LastName = request.lastName,
                Identification = request.identification,
                Address = request.address,
                Phone = request.phone,
                Email = request.email,
                City = request.city,
                State = request.state,
                Country = request.country,
            };
            try
            {

                var result = await _clientRepository.UpdateClientAsync(clientData, request.id, cancellationToken);

                if (result)
                {
                    return clientData;
                }

                return Result.Failure<Client>(Error.None);
            }
            catch
            {

                return Result.Failure<Client>(Error.None);
            }
        }

    }
}