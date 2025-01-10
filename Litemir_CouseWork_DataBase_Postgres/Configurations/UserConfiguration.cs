using Litemir_CouseWork_DataBase_Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Litemir_CouseWork_DataBase_Postgres.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Works)
                .WithOne(c => c.User);
         }
    }
}
