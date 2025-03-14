using Domain.Employees;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class EmployeesConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employee");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(x => x.LastName);
            builder.Property(x => x.Created_at);
            builder.Property(x => x.Updated_at);
            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(x => x.UserId);
        }
    }
}