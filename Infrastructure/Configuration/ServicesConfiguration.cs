using Domain.Services;
using Domain.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Servicios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TradeId)
                   .IsRequired();
            builder.Property(x => x.NameService)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(x => x.OpeningHour)
                   .IsRequired();
            builder.Property(x => x.ClosingHour)
                    .IsRequired();
            builder.Property(x => x.Duration)
                    .IsRequired();

            builder.HasOne<Trade>()
                   .WithMany()
                   .HasForeignKey(x => x.TradeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}