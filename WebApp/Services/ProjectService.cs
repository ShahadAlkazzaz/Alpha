using WebApp.Models.Entities;
using WebApp.Repositories;

namespace WebApp.Services
{
    // AI-genererad kod: Använder Service Pattern för att separera affärslogik från controller och repository.
    public class ProjectService
    {
        private readonly ProjectRepository _repository;

        public ProjectService(ProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ProjectEntity?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(ProjectEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(ProjectEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(ProjectEntity entity)
        {
            await _repository.DeleteAsync(entity);
        }


    }
}
