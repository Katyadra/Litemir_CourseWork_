using Litemir_CouseWork_DataBase_Postgres.Configurations;
using Litemir_CouseWork_DataBase_Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace Litemir_CouseWork_DataBase_Postgres;
public class LearningDbContext(DbContextOptions<LearningDbContext> options)
        : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }

    public DbSet<WorkEntity> Works { get; set; }

    public DbSet<ChapterEntity> Chapters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ChapterConfiguration());
        modelBuilder.ApplyConfiguration(new WorkConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}


