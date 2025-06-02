using AFTT.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFTT.EF.Configurations;

internal class UserDbEntityConfiguration : IEntityTypeConfiguration<UserDbEntity>
{
    public void Configure(EntityTypeBuilder<UserDbEntity> builder)
    {
        builder.ToTable("User", "user");

        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Missions)
            .WithOne(x => x.Owner)
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Settings)
            .WithOne(x => x.Owner)
            .HasForeignKey<UserSettingsDbEntity>(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Id)
           .ValueGeneratedOnAdd()
           .IsRequired();

        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(100);
    }
}