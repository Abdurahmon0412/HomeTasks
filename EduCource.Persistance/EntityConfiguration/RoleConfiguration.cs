using EduCource.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCource.Persistance.EntityConfiguration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(role => role.UserId);

        builder.HasOne<User>().WithOne();

        // .HasForeignKey<Role>(role => role.UserId)
        // .HasPrincipalKey<Role>(role => role.UserId);
    }
}