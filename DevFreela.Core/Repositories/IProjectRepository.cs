using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync(ProjectQueryDTO queryDTO);
        Task<Project> GetByIdAsync(int id);
        Task<Project> GetDetailsByIdAsync(int id);
        Task AddAsync(Project project);
        Task AddCommentAsync(ProjectComment projectComment);
        Task SaveChangesAsync();
        Task DeleteAsync(int id);
        Task StartAsync(int id);
        Task UpdateAsync(int id, string title, string description, decimal totalCost);
        Task FinishAsync(int id);

    }
}
