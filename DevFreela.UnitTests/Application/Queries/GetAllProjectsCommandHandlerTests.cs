using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async void ThreeProjectsExists_Executed_ReturnThreeProjectsViewModels()
        {
            //Arrange
            var projects = new List<Project>()
            {
                new Project("Nome do teste 1","Descrição do teste 1",1,2,100),
                new Project("Nome do teste 2","Descrição do teste 2",1,2,300),
                new Project("Nome do teste 3","Descrição do teste 3",1,2,200)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectsViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectsViewModelList);
            Assert.NotEmpty(projectsViewModelList);
            Assert.Equal(projectsViewModelList.Count, projects.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
