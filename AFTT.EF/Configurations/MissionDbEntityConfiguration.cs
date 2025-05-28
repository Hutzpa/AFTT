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
    }
}