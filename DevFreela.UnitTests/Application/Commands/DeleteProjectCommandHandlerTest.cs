using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class DeleteProjectCommandHandlerTest
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnVoid()
        {
            //Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();
            var deleteProjectCommand = new DeleteProjectCommand(1);

            var deleteProjectCommandHandler = new DeleteProjectCommandHandler(projectRepositoryMock.Object);
            //Act

            await deleteProjectCommandHandler.Handle(deleteProjectCommand, new CancellationToken());

            //Assert
            projectRepositoryMock.Verify(pr => pr.DeleteAsync(It.IsAny<int>()), Times.Once);

        }
    }
}
