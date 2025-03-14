using Application.Abstractions.Messaging;
using Application.DetailInvoices;
using Domain.Abstractions;
using Domain.Invoice;
using Domain.InvoiceDetail;
using Domain.Product;
using MediatR;


namespace Application.Invoices
{
    public class CreatedInvoiceCommandHandler : ICommandHandler<CreatedInvoiceCommand, Guid>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublisher _publisher;
        private readonly List<INotification> _domainEvents = new List<INotification>();

        public CreatedInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork, IPublisher publisher)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
            _publisher = publisher;
        }
        public async Task<Result<Guid>> Handle(CreatedInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.GetByInvoiceAsync(request.docName, cancellationToken);

            if (invoice is null)
            {
                try
                {

                    var invoiceData = Invoice.Created(request.clientId, DateTime.UtcNow, request.docClass, request.docNumber, request.docName, request.total);

                    _invoiceRepository.Add(invoiceData);

                    await _unitOfWork.SaveChangedAsync(cancellationToken);


                    foreach (var invoiceDetail in request.InvoiceDetails)
                    {

                        // Publicar el evento de dominio
                        var detailInvoiceCreatedEvent = new DetailInvoiceCreatedEvent(invoiceData.Id,
                                                                                      invoiceDetail.IdProducts,
                                                                                      invoiceDetail.Amount,
                                                                                      invoiceDetail.PriceUnit,
                                                                                      invoiceDetail.SubTotal,
                                                                                      invoiceDetail.DeliveryDate,
                                                                                      invoiceDetail.DeliveryTime,
                                                                                      invoiceDetail.Deposit);

                        await _publisher.Publish(detailInvoiceCreatedEvent, cancellationToken);

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