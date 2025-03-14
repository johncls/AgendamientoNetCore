using Domain.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    internal sealed class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        /// <summary>
        /// Configuracion de la tabla
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("clients");
            builder.HasKey(client => client.Id);
            builder.Property(client => client.Identification)
                    .IsRequired()
                    .HasMaxLength(15);
            builder.Property(client => client.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(client => client.LastName);
            builder.Property(client => client.Phone);
            builder.Property(client => client.Email)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(client => client.Address);
            builder.Property(client => client.City);
            builder.Property(client => client.State);
            builder.Property(client => client.Country);
        }
    }
}