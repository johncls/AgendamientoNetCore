using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.InvoiceDetail;
using MediatR;

namespace Application.DetailInvoices.UpdateDetailInvoice
{
    public class UpdateDetailInvoiceCommandHandler : INotificationHandler<DetailInvoiceUpdateEvent>
    {
        private readonly IInvoiceDetailRepository _datialInvoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDetailInvoiceCommandHandler(IInvoiceDetailRepository invoiceDetailRepository, IUnitOfWork unitOfWork)
        {
            _datialInvoiceRepository = invoiceDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DetailInvoiceUpdateEvent notification, CancellationToken cancellationToken)
        {
            var detailInvoice =  new InvoiceDetail(
                notification.Id,
                notification.InvoiceId,
                notification.ProductId,
                notification.Amount,
                notification.PriceUnit,
                notification.SubTotal,
                notification.DeliveryDate,
                notification.DeliveryTime,
                notification.Deposit
            );

            var result = await _datialInvoiceRepository.UpdateClientAsync(detailInvoice, notification.InvoiceId, cancellationToken);

            if (!result)
            {
                throw new Exception("Error updating detail invoice");
            }

            await _unitOfWork.SaveChangedAsync(cancellationToken);
        }
    }
}