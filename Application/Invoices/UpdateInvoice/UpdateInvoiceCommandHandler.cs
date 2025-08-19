using Application.Abstractions.Messaging;
using Application.DetailInvoices;
using Application.DetailInvoices.UpdateDetailInvoice;
using Domain.Abstractions;
using Domain.Invoice;
using MediatR;

namespace Application.Invoices.UpdateInvoice
{
    public class UpdateInvoiceCommandHandler : ICommandHandler<UpdateInvoiceCommand, Guid>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublisher _publisher;

        public UpdateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork, IPublisher publisher)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
            _publisher = publisher;
        }


        public async Task<Result<Guid>> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.GetByInvoiceAsync(request.docName, cancellationToken);

            if (invoice != null)
            {
                try
                {
                    var updatedInvoice = new Invoice(
                        request.id,
                        request.clientId,
                        request.DataCreated,
                        request.docClass,
                        request.docNumber,
                        request.docName,
                        request.total
                    );
                    
                    var invoiceData = await _invoiceRepository.UpdateInvoiceAsync(updatedInvoice, request.docClass, cancellationToken);

                    if (invoiceData is null)
                    {
                        return Result.Failure<Guid>(Error.Invoice);
                    }

                    foreach (var invoiceDetail in request.InvoiceDetails)
                    {

                        // Publicar el evento de dominio
                        var detailInvoiceUpdatedEvent = new DetailInvoiceUpdateEvent( invoiceDetail.Id,
                                                                                      invoiceData.Id,
                                                                                      invoiceDetail.IdProducts,
                                                                                      invoiceDetail.Amount,
                                                                                      invoiceDetail.PriceUnit,
                                                                                      invoiceDetail.SubTotal,
                                                                                      invoiceDetail.DeliveryDate,
                                                                                      invoiceDetail.DeliveryTime,
                                                                                      invoiceDetail.Deposit ? 1m : 0m);

                        await _publisher.Publish(detailInvoiceUpdatedEvent, cancellationToken);

                    }

                    return  invoiceData.Id;
                }
                catch
                {

                    return Result.Failure<Guid>(Error.Invoice);
                }
            }

            return Result.Failure<Guid>(Error.Invoice);

        }
    }
}