using Domain.Invoice;
using Domain.InvoiceDetail;
using Domain.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    internal sealed class DetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.ToTable("details_invoice");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Amount)
                    .IsRequired()
                    .HasMaxLength(10); 
            builder.Property(x => x.PriceUnit)
                    .IsRequired()
                    .HasMaxLength(10);
            builder.Property(x => x.SubTotal);
            builder.Property(x => x.DeliveryDate)
                    .IsRequired()
                    .HasMaxLength(200);
            builder.Property(x => x.DeliveryTime);
            builder.Property(x => x.Deposit);
            builder.HasOne<Invoice>()
                   .WithMany()
                   .HasForeignKey(x => x.IdInvoice);
            builder.HasOne<Product>()
                   .WithMany()
                   .HasForeignKey(x => x.IdProduct);
        }
    }
}