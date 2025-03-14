
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.InvoiceDetail;
using MediatR;

namespace Application.DetailInvoices
{
    public class CreatedDetailInvoiceHandler : INotificationHandler<DetailInvoiceCreatedEvent>
    {
        private readonly IInvoiceDetailRepository _datialInvoiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreatedDetailInvoiceHandler(IInvoiceDetailRepository invoiceDetailRepository, IUnitOfWork unitOfWork)
        {
            _datialInvoiceRepository = invoiceDetailRepository;
            _unitOfWork = unitOfWork;
        }

        async Task INotificationHandler<DetailInvoiceCreatedEvent>.Handle(DetailInvoiceCreatedEvent notification, CancellationToken cancellationToken)
        {
            var detailInvoice = InvoiceDetail.Created(
                notification.InvoiceId,
                notification.ProductId,
                notification.Amount,
                notification.PriceUnit,
                notification.SubTotal,
                notification.DeliveryDate,
                notification.DeliveryTime,
                notification.Deposit
            );

            _datialInvoiceRepository.Add(detailInvoice);

            await _unitOfWork.SaveChangedAsync(cancellationToken);

            
        }
    }
}