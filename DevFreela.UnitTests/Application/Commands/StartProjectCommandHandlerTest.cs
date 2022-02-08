using DevFreela.Application.Commands.StartProject;
using DevFreela.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class StartProjectCommandHandlerTest
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnVoid()
        {
            //Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var finishProjectCommand = new StartProjectCommand(1);
            var finishProjectCommandHandler = new StartProjectCommandHandler(projectRepositoryMock.Object);

            //Act

            await finishProjectCommandHandler.Handle(finishProjectCommand, new CancellationToken());

            //Assert
            projectRepositoryMock.Verify(pr => pr.StartAsync(It.IsAny<int>()), Times.Once);

        }
    }
}
