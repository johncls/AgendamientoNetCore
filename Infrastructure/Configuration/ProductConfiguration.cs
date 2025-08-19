using Domain.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(x => x.CodeProduct)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(x => x.Price)
                    .IsRequired()
                    .HasMaxLength(10);
            builder.Property(x  => x.Amount)
                    .HasMaxLength(10);
            builder.Property(x => x.UnitOfMeasurement)
                    .HasMaxLength(10);                
            builder.Property(x => x.DateCreated);
        }
    }
}