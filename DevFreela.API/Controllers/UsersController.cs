using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _userService.GetById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel inputModel)
        {
            var id = _userService.Create(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

     //   [HttpPut("{id}/login")]
     //   public IActionResult Login(int id, [FromBody] LoginModel loginModel)
     //   {
     //
     //       return NoContent();
     //   }
    }
}



