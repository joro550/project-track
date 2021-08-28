using MediatR;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Track.Persistence;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Versions.Models;
using Project.Track.Shared.Versions;

namespace Project.Track.Server.Versions
{
    [ApiController]
    [Route("api/v1/solutions/{solutionId}/versions")]
    public class VersionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<VersionEntity> _versions;

        public VersionController(IRepository<VersionEntity> versions, IMediator mediator)
        {
            _versions = versions;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string solutionId)
        {
            var branchEntities = await _versions.GetAsync(parameters: solutionId);
            return Ok(branchEntities.Select(e => e.FromEntity()));
        }
        
        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(string id, string solutionId)
        {
            var versions = await _versions.GetAsync(id, solutionId);
            if (!versions.Any())
                return NotFound();

            var featureEntity = versions.First();
            return Ok(featureEntity.FromEntity());
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]VersionModel featureModel, string solutionId)
        {
            var versionId = await _mediator.Send(featureModel.ToRequest(solutionId));
            return Created($"api/v1/solutions/{solutionId}/versions/{versionId}", versionId);
        }
    }
}