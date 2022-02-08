using DevFreela.Application.Commands.FinishProject;
using DevFreela.Core.Repositories;
using Moq;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class FinishProjectCommandHandlerTest
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnVoid()
        {
            //Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var finishProjectCommand = new FinishProjectCommand(1);
            var finishProjectCommandHandler = new FinishProjectCommandHandler(projectRepositoryMock.Object);

            //Act

            await finishProjectCommandHandler.Handle(finishProjectCommand, new CancellationToken());

            //Assert
            projectRepositoryMock.Verify(pr => pr.FinishAsync(It.IsAny<int>()), Times.Once);

        }
    }
}
