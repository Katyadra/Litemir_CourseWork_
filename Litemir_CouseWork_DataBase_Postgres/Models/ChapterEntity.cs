namespace Litemir_CouseWork_DataBase_Postgres.Models
{
    public class ChapterEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public Guid WorkId {  get; set; }

        public WorkEntity? Work { get; set; }
    }
}
