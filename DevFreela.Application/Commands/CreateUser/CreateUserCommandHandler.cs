using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService) 
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var EmailExist = await _userRepository.GetByEmail(request.Email);
            if (EmailExist != null)
                return -1;

            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);
            await _userRepository.AddAsync(user);
            return user.Id;
        }
    }
}
