using Litemir_CouseWork_DataBase_Postgres.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Litemir_CouseWork_DataBase_Postgres.Configurations
{
    public class WorkConfiguration : IEntityTypeConfiguration<WorkEntity>
    {
        public void Configure(EntityTypeBuilder<WorkEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.User)
                .WithMany(c => c.Works);

            builder.HasMany(l => l.Chapters)
                .WithOne(w => w.Work)
                .HasForeignKey(l => l.WorkId);
        }
    }
}
