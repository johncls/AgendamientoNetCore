using Application.Abstractions.Behaviors.Data;
using Application.Abstractions.Messaging;
using Dapper;
using Domain.Abstractions;
using MediatR;

namespace Application.Products.GetProducts
{
    public sealed class GetProductQueryHandler: IQueryHandler<GetProductQuery, ProductResponse>
    {
        private readonly ISqlConnecionFactory _sqlConnecionFactory;

        public GetProductQueryHandler(ISqlConnecionFactory sqlConnecionFactory)
        {
            _sqlConnecionFactory = sqlConnecionFactory;
        }

        public async Task<Result<ProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnecionFactory.CreateConnection();

            var sql = String.Format(
              @"SELECT
                id AS Id,
                name As Name,
                price AS Price,
                date_created AS DateCreated
           FROM public.product WHERE id=@productId"
            );
            var product = await connection.QueryFirstOrDefaultAsync<ProductResponse>(sql, new { request.productId });

            return product;
        }

    }
}