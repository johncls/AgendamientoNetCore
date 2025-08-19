using Application.Abstractions.Behaviors.Data;
using Application.Abstractions.Messaging;
using Dapper;
using Domain.Abstractions;

namespace Application.Clients.GetClient
{
    public sealed class GetClientQueryHandler : IQueryHandler<GetClientQuery, ClientResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetClientQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<ClientResponse>> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            var sql =
              @"SELECT
                id AS Id,
                identification As identification,
                name AS Name,
                last_name AS LastName,
                phone AS Phone,
                address AS Address,
                email AS Email,
                city AS City, 
                state AS State,
                country As Country
           FROM public.clients WHERE id=@clientId"
            ;

            var client = await connection.QueryFirstOrDefaultAsync<ClientResponse>(
                sql, 
                new { request.clientId },
                commandTimeout: null);

            return (Result<ClientResponse>)(client != null
                ? Result<ClientResponse>.Success(client)
                : Result<ClientResponse>.Failure(Error.ClientNotFound));
        }
    }
}