using Litemir_CouseWork_DataBase_Postgres.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Litemir_CouseWork_DataBase_Postgres.Repositories
{
    public class WorkRepository
    {
        private readonly LearningDbContext _dbContext;

        public WorkRepository(LearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task <List<WorkEntity>> Get()
        {
            return await _dbContext.Works
                .AsNoTracking()
                .OrderBy(x => x.Title)
                .ToListAsync();
        }

        public async Task<List<WorkEntity>> GetWithChapters()
        {
            return await _dbContext.Works
                .AsNoTracking()
                .Include(c => c.Chapters)
                .ToListAsync();
        }

        public async Task<WorkEntity?> GetById(Guid id)
        {
            return await _dbContext.Works
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<WorkEntity>> GetByFilter(string title)
        {
            var query = _dbContext.Works.AsNoTracking();
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(c =>  c.Title.Contains(title));
            }

            return await query.ToListAsync();
        }

        public async Task<List<WorkEntity>> GetByPage(int page, int pageSize) // Пагинация
        {
            return await _dbContext.Works
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task Add(Guid id, Guid authorId, string title, string description)
        {
            var workEntity = new WorkEntity()
            {
                Id = id,
                AuthorId = authorId,
                Title = title,
                Description = description
            };

            await _dbContext.AddAsync(workEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Guid id, Guid authorId, string title, string description)
        {
            var workEntity = await _dbContext.Works.FirstOrDefaultAsync(c => c.Id == id)
                ?? throw new Exception();
            workEntity.Title = title;
            workEntity.Description = description;
            
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update2(Guid id, Guid authorId, string title, string description)
        {
            await _dbContext.Works.
                Where(c => c.Id == id)
                .ExecuteUpdateAsync(s =>
                s.SetProperty(c => c.Title, title)
                .SetProperty(c => c.Description, description));
        }

        public async Task Delete(Guid id) // Удаление
        {
            await _dbContext.Works
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
        }
    }

   

    }
}
