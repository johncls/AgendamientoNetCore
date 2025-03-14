using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(x => x.Password)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(x => x.Role);
            builder.Property(x => x.Created_at);
            builder.Property(x => x.Updated_at);
        }
    }
}