namespace Litemir_CouseWork_DataBase_Postgres.Models
{
    public class WorkEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Guid AuthorId { get; set; }

        public UserEntity? User { get; set; }

        public List<ChapterEntity> Chapters { get; set; } = [];
    }
}
