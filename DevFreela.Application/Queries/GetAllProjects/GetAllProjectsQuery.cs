using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System.Collections.Generic;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery:IRequest<List<ProjectViewModel>>
    {
        public GetAllProjectsQuery(string query)
        {
            this.query = query;
        }

        public string query { get; private set; }
    }
}
