using Microsoft.AspNetCore.Mvc;
using DevFreela.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _options;
        public ProjectsController(IOptions<OpeningTimeOption> options)
        {
            _options = options.Value;
        }
        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject) 
        {
            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject) 
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentModel createComent)
        {
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start()
        {
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }
    }
}
