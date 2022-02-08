using DevFreela.Application.Commands.CreateUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTest
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUserId()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();

            var userCommand = new CreateUserCommand
            {
                FullName = "Name",
                Email = "email@teste.com",
                Password = "SAD@@5123313a%$#",
                Role = "Client",
                BirthDate = DateTime.Now
            };

            var userCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object, authServiceMock.Object);

            // Act

            var id = await userCommandHandler.Handle(userCommand, new CancellationToken());

            // Assert
            Assert.True(id >= 0);
            userRepositoryMock.Verify(ur=>ur.GetByEmail(It.IsAny<String>()),Times.Once);
            userRepositoryMock.Verify(ur => ur.AddAsync(It.IsAny<User>()), Times.Once);

            authServiceMock.Verify(ur => ur.ComputeSha256Hash(It.IsAny<String>()), Times.Once);

        }
    }
}
