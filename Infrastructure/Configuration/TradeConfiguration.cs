using Domain.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class TradeConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.ToTable("Comercios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NameTrade)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(x => x.MaximunCapacity)
                   .IsRequired();
        }
    }
}