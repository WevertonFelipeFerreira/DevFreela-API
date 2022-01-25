using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserQuery(id);
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            if(id == -1) 
            {
               return UnprocessableEntity(new {Title = "Unprocessable Entity", Status = 422,Detail = "Email already exist." });
            }

            var response = new { fullName = command.FullName, email = command.Email, role = command.Role };

            return CreatedAtAction(nameof(GetById), new { id = id }, response);
        }

        [HttpPut("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginModel)
        {
            var loginUser = await _mediator.Send(loginModel);

            if(loginUser == null)
            {
                var response = new {Title = "Bad Request",Status = 400, Detail = "Email or password incorrect"};
                return BadRequest(response);
            }

            return Ok(loginUser);
        }
    }
}



