using DevFreela.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
    {
        public GetAllProjectsQuery()
        {
            
        }
        public GetAllProjectsQuery(string totalCostHigherThan, string text)
        {
            TotalCostHigherThan = totalCostHigherThan;
            Text = text;
        }

        [FromQuery(Name = "totalCostHigherThan")]
        public string TotalCostHigherThan { get; set; }

        [FromQuery(Name = "text")]
        public string Text { get; set; }
    }
}
