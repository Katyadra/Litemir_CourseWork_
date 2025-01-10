using Litemir_CouseWork_DataBase_Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace Litemir_CouseWork_DataBase_Postgres.Repositories
{
    public class ChapterRepository
    {
        private readonly LearningDbContext _dbContext;

        public ChapterRepository(LearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddChapter(Guid workId, ChapterEntity chapter)
        {
            var work = await _dbContext.Works.FirstOrDefaultAsync(c => c.Id == workId)
                ?? throw new Exception();

            work.Chapters.Add(chapter);

            await _dbContext.SaveChangesAsync();
        }

        public async Task AddChapter2(Guid workId, string title)
        {
            var chapter = new ChapterEntity
            {
                Title = title,
                WorkId = workId
            };
            await _dbContext.AddAsync(chapter);
        }

        public async Task Delete(Guid id) // Удаление
        {
            await _dbContext.Chapters
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
