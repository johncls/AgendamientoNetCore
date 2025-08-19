using Application.Abstractions.Behaviors.Data;
using Application.Abstractions.Messaging;
using Application.Clients.GetClient;
using Application.DetailInvoices.GetDetailInvoice;
using Application.Products.GetProducts;
using Dapper;
using Domain.Abstractions;

namespace Application.Invoices.GetInvoice
{
    public class GetInvoiceQueryHandler : IQueryHandler<GetInvoiceQuery, InvoiceResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetInvoiceQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<InvoiceResponse>> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            var sql = @"
                        SELECT 
                            inv.id AS InvoiceId, 
                            inv.date_created AS DateCreated, 
                            inv.doc_number AS DocNumber, inv.doc_name AS DocName, 
                            inv.doc_class AS DocClass, 
                            inv.total AS Total,

                            cli.name AS ClientName, 
                            cli.identification, 
							cli.phone, cli.email, 
							cli.address, 
							cli.city, cli.state,

                            dinv.id AS IdInvoiceDetail, 
                            dinv.id_product AS ProductId, 
                            dinv.amount AS Amount, 
                            dinv.price_unit AS PriceUnit, 
                            dinv.sub_total AS SubTotal, 
                            dinv.delivery_date AS DeliveryDate, 
                            dinv.delivery_time AS DeliveryTime, 
                            dinv.deposit AS Deposit, 

                            pro.name AS ProductName

                        FROM public.invoice AS inv
                        INNER JOIN public.clients AS cli ON inv.id_client = cli.id
                        INNER JOIN public.details_invoice AS dinv ON inv.id = dinv.id_invoice
                        INNER JOIN public.product AS pro ON dinv.id_product = pro.id
                        WHERE 1=1
                    ";

            // Construir dinámicamente las condiciones de filtrado
            if (request.invoiceId != Guid.Empty)
            {
                sql += " AND inv.id = @InvoiceId";
            }
            if (!string.IsNullOrEmpty(request.DocName))
            {
                sql += " AND inv.doc_name = @DocName";
            }
            if (request.CreatedDate.HasValue)
            {
                sql += " AND inv.date_created = @CreatedDate";
            }
            if (request.ClientId.HasValue)
            {
                sql += " AND inv.id_client = @ClientId";
            }

            var invoiceDictionary = new Dictionary<Guid, InvoiceResponse>();

            var invoice = await connection.QueryAsync<InvoiceResponse, DetailInvoiceResponse, InvoiceResponse>(
                sql,
                (invoice, detail) =>
                {
                    if (!invoiceDictionary.TryGetValue(invoice.InvoiceId, out var invoiceEntry))
                    {
                        invoiceEntry = invoice;
                        invoiceEntry.invoiceDetails = new List<DetailInvoiceResponse>();
                        invoiceDictionary.Add(invoice.InvoiceId, invoiceEntry);
                    }
                    invoiceEntry.invoiceDetails.Add(detail);
                    return invoiceEntry;
                },
                new
                {
                    request.invoiceId,
                    request.DocName,
                    request.CreatedDate,
                    request.ClientId
                },
                splitOn: "IdInvoiceDetail"
            );

            var result = invoiceDictionary.Values.FirstOrDefault();

            return (Result<InvoiceResponse>)(result != null
                ? Result<InvoiceResponse>.Success(result)
                : Result<InvoiceResponse>.Failure(Error.InvoiceNotFound));
        }
    }
}