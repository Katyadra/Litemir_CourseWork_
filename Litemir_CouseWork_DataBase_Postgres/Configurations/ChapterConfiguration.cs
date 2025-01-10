using Litemir_CouseWork_DataBase_Postgres.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Litemir_CouseWork_DataBase_Postgres.Configurations
{
    public class ChapterConfiguration : IEntityTypeConfiguration<ChapterEntity>
    {
        public void Configure(EntityTypeBuilder<ChapterEntity> builder)
        {
            builder.HasOne(l => l.Work)
                .WithMany(c => c.Chapters)
                .HasForeignKey(b => b.WorkId);
        }
    }
}
