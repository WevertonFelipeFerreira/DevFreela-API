using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using System.Threading;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            // Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Titulo teste",
                Description = "Descrição test",
                IdClient = 1,
                IdFreelancer = 2,
                TotalCost = 20000
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepositoryMock.Object);
            //Act

            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            //Assert

            Assert.True(id >= 0);
            projectRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Project>()),Times.Once);
        }
    }
}
