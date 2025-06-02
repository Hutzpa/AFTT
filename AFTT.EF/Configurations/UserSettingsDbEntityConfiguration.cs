using AFTT.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFTT.EF.Configurations;

internal class UserSettingsDbEntityConfiguration : IEntityTypeConfiguration<UserSettingsDbEntity>
{
    public void Configure(EntityTypeBuilder<UserSettingsDbEntity> builder)
    {
        builder.ToTable("Settings", "user");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.Language)
            .HasMaxLength(10);

        builder.Property(x => x.Timezone)
            .HasMaxLength(10);
    }
}