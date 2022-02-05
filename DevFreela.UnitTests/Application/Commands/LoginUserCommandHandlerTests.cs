using DevFreela.Application.Commands.LoginUser;
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
    public class LoginUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_LoginUserViewModel()
        {
            // Arrange

            var user = new User(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>());

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(ur => ur.GetByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>()).Result).Returns(user);

            var AuthServiceMock = new Mock<IAuthService>();
            
            var loginUserCommand = new LoginUserCommand
            {
                Email = It.IsAny<string>(),
                Password = It.IsAny<string>()
            };
            var loginUserCommandHandler = new LoginUserCommandHandler(userRepositoryMock.Object, AuthServiceMock.Object);

            // Act

            var result = await loginUserCommandHandler.Handle(loginUserCommand, new CancellationToken());

            // Assert

            Assert.NotNull(result);

            userRepositoryMock.Verify(ur => ur.GetByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            AuthServiceMock.Verify(x => x.ComputeSha256Hash(It.IsAny<string>()), Times.Once);
            AuthServiceMock.Verify(x => x.GenerateJwtToken(It.IsAny<string>(), It.IsAny<string>()), Times.Once);

        }

    }
}
