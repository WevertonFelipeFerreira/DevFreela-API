using DevFreela.Application.Commands.CreateComment;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateCommentCommandHandlerTest
    {
        [Fact]
        public async Task inputDataIsOk_Executed_ReturnVoid()
        {
            // Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var commentCommand = new CreateCommentCommand
            {
                Content = "Comentario",
                IdUser = 1,
                IdProject = 2

            };
            var createCommentCommandHandler = new CreateCommentHandler(projectRepositoryMock.Object);

            // Act

            var response = await createCommentCommandHandler.Handle(commentCommand, new CancellationToken());

            // Assert

            projectRepositoryMock.Verify(x => x.AddCommentAsync(It.IsAny<ProjectComment>()),Times.Once);

        }
    }
}
