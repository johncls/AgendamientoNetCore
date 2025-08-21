using Domain.Services;
using Domain.Shifts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ShiftsConfiguration : IEntityTypeConfiguration<Shifts>
    {
        public void Configure(EntityTypeBuilder<Shifts> builder)
        {
            builder.ToTable("Turnos");
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.ServiceId)
                   .IsRequired();
            
            builder.Property(x => x.ShiftDate)
                   .IsRequired();
            
            builder.Property(x => x.StartTime)
                   .IsRequired();
            
            builder.Property(x => x.EndTime)
                   .IsRequired();
            
            builder.Property(x => x.State)
                   .IsRequired();
                   
            builder.HasOne<Service>()
                   .WithMany()
                   .HasForeignKey(x => x.ServiceId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}