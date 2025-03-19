using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Inventory;
using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("inventory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LastUpdate)
                    .IsRequired()
                    .HasMaxLength(10); 
            builder.Property(x => x.Quantity)
                    .IsRequired()
                    .HasMaxLength(10);
            builder.HasOne<Product>()
                   .WithMany()
                   .HasForeignKey(x => x.IdProduct);
        }
    }
}