using AFTT.EF.Configurations;
using AFTT.EF.Model;
using AFTT.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AFTT.EF;

public class MissionContext : DbContext
{
    public DbSet<MissionDbEntity> Missions { get; set; }
    public DbSet<UserDbEntity> Users { get; set; }

    public MissionContext(DbContextOptions<MissionContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MissionDbEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserDbEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserSettingsDbEntityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}