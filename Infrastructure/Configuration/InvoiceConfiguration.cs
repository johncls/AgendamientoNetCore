using Domain.Client;
using Domain.Invoice;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoice");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DateCreated);
            builder.Property(x => x.DocClass);
            builder.Property(x => x.DocNumber);
            builder.Property(x => x.Total)
                   .IsRequired()
                   .HasMaxLength(10);
            builder.HasOne<Client>()
                   .WithMany()
                   .HasForeignKey(x => x.IdClient);
        }
    }
}