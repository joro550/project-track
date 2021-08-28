using MediatR;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Track.Persistence;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Solutions.Commands;
using Project.Track.Server.Solutions.Extensions;
using Project.Track.Shared.Solutions;

namespace Project.Track.Server.Solutions
{
    [ApiController]
    [Route("api/v1/solutions")]
    public class SolutionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<SolutionEntity> _solutions;

        public SolutionController(IRepository<SolutionEntity> solutions, IMediator mediator)
        {
            _solutions = solutions;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() 
            => Ok(await _solutions.GetAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var solution = await _solutions.GetAsync(id);
            if (!solution.Any())
                return NotFound();
            
            var firstSolution = solution.First();
            return Ok(firstSolution.ToModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]SolutionModel getSolutionModel)
        {
            var solutionId = await _mediator.Send(new CreateSolution(getSolutionModel));
            return Created($"/api/v1/solutions/{solutionId}", solutionId);
        }
    }
}