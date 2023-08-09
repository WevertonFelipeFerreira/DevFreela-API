using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Project>> GetAllAsync(ProjectQueryDTO query)
        {
            IQueryable<Project> projects = _dbContext.Projects;

            if (query.Text is not null)
            {
                projects = projects.Where(x => x.Description.Contains(query.Text) || x.Title.Contains(query.Text));
            }

            if (query.TotalCostHigherThan is not null)
            {
                projects = projects.Where(x => x.TotalCost > decimal.Parse(query.TotalCostHigherThan));
            }

            return await projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _dbContext.Projects.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Project> GetDetailsByIdAsync(int id)
        {
            return await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);

            await _dbContext.SaveChangesAsync();
        }

        public async Task AddCommentAsync(ProjectComment projectComment)
        {
            await _dbContext.ProjectComments.AddAsync(projectComment);

            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(x => x.Id == id);

            project.Cancel();

            await _dbContext.SaveChangesAsync();
        }

        public async Task StartAsync(int id)
        {
            var project = await GetByIdAsync(id);

            project.Start();

            await _dbContext.SaveChangesAsync();
        }

        public async Task FinishAsync(int id)
        {
            var project = await GetByIdAsync(id);

            project.Finish();

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, string title, string description, decimal totalCost)
        {
            var project = await GetByIdAsync(id);

            project.Update(title, description, totalCost);

            await _dbContext.SaveChangesAsync();
        }
    }
}
