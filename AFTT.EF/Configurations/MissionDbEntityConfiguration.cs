using AFTT.EF.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFTT.EF.Configurations;

internal class MissionDbEntityConfiguration : IEntityTypeConfiguration<MissionDbEntity>
{
    public void Configure(EntityTypeBuilder<MissionDbEntity> builder)
    {
        builder.ToTable("Missions", "mission");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasMaxLength(500);
    }   
}