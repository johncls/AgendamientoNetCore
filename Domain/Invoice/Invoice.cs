using Domain.Abstractions;
using Domain.Invoice.Event;

namespace Domain.Invoice
{
    public class Invoice : Entity
    {
        public Invoice()
        {

        }

        public Invoice(
            Guid id,
            Guid idClient,
            DateTime dateCreated,
            string docClass,
            int docNumber,
            string docName,
            decimal total) : base(id)
        {
            IdClient = idClient;
            DateCreated = dateCreated;
            DocClass = docClass;
            DocNumber = docNumber;
            DocName = docName;
            Total = total;
        }
        /// <summary>
        /// id del cliente
        /// </summary>
        public Guid IdClient { get;  set; }
        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime DateCreated { get;  set; }
        /// <summary>
        /// Doc class de la factura 
        /// </summary>
        public string DocClass { get; set; } = string.Empty;
        /// <summary>
        /// Consecutivo de la factura
        /// </summary>
        public int DocNumber { get;  set; } = 0;
        /// <summary>
        /// Nombre del conscutivo
        /// </summary>
        public string DocName { get;  set; } = string.Empty;
        /// <summary>
        /// total de la factura
        /// </summary>
        public decimal Total { get;  set; }

        public static Invoice Created(Guid idClient, DateTime dateCreated, string docClass, int docNumber, string docName,decimal total)
        {
            var invoice = new Invoice(
                Guid.NewGuid(),
                idClient,
                dateCreated,
                docClass,
                docNumber,
                docName,
                total
            );

            invoice.RaiseDomainEvent(new InvoiceCreatedDomainEvent(invoice.Id));

            return invoice;
        }

    }
}