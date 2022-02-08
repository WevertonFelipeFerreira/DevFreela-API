using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DevFreela.Core.Entities;

namespace DevFreela.UnitTests.Application.Commands
{
    public class UpdateProjectCommandHandlerTest
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnVoid()
        {
            // Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var updateProjectCommand = new UpdateProjectCommand
            {
                Id = 1,
                Title = "Title",
                Description = "Descrição",
                TotalCost = 20000
            };

            var updateProjectCommandHandler = new UpdateProjectCommandHandler(projectRepositoryMock.Object);

            // Act
            await updateProjectCommandHandler.Handle(updateProjectCommand, new CancellationToken());

            // Assert
            projectRepositoryMock.Verify(pr => pr.UpdateAsync(updateProjectCommand.Id, updateProjectCommand.Title, updateProjectCommand.Description, updateProjectCommand.TotalCost), Times.Once);

        }
    }
}
