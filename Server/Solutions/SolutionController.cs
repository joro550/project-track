using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Project.Track.Server.Solutions
{
    [Route("api/v1/solutions")]
    public class SolutionController : ControllerBase
    {
        private readonly List<Solution> _solutions = new()
        {
            new(1, "SkyRise"),
            new(2, "SkyFall"),
            new(3, "SkyLake"),
            new(4, "OtherThing")
        };
        
        [HttpGet]
        public IActionResult GetAsync()
        {
            return Ok(_solutions);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAsync(int id)
        {
            var solution = _solutions.FirstOrDefault(solution => solution.Id == id);
            if (solution is null)
                return NotFound();
            
            return Ok(solution);
        }

        [HttpPost]
        public IActionResult CreateAsync(Solution solution)
        {
            _solutions.Add(solution);
            return Created($"/api/v1/solutions/{solution.Id}", solution);
        }
    }

    public record Solution(int Id, string Name);
}