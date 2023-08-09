using DevFreela.Application.ViewModels;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;
        public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projectQuery = new ProjectQueryDTO() { Text = request.Text, TotalCostHigherThan = request.TotalCostHigherThan };
            var projects = await _projectRepository.GetAllAsync(projectQuery);

            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.Description, p.TotalCost, p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }
    }
}
