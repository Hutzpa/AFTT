using AFTT.EF.Configurations;
using AFTT.EF.Model;
using Microsoft.EntityFrameworkCore;

namespace AFTT.EF;

public class MissionContext : DbContext
{
    public DbSet<MissionDbEntity> Missions { get; set; }

    public MissionContext(DbContextOptions<MissionContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MissionDbEntityConfiguration());
    }
}
