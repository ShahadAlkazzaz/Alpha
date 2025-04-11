using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models.Entities;

namespace WebApp.Repositories
{
    // AI-genererad kod: Repository Pattern används för att separera datalagringslogik från övrig affärslogik.
    public class ProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<ProjectEntity?> GetByIdAsync(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(ProjectEntity entity)
        {
            _context.Projects.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProjectEntity entity)
        {
            _context.Projects.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProjectEntity entity)
        {
            _context.Projects.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
