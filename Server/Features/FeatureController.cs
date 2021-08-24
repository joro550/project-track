using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Track.Persistence;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Features.Models;

namespace Project.Track.Server.Features
{
    [ApiController]
    [Route("api/v1/solutions/{solutionId:guid}/features")]
    public class FeatureController : ControllerBase
    {
        private readonly IRepository<FeatureEntity> _features;

        public FeatureController(IRepository<FeatureEntity> features) 
            => _features = features;
        
        [HttpGet]
        public async Task<IActionResult> GetAsync(Guid solutionId)
        {
            var branchEntities = await _features.GetAsync();
            return Ok(branchEntities.Select(GetFeatureModel.FromEntity));
        }
        
        [HttpGet("id:guid")]
        public async Task<IActionResult> GetAsync(Guid id, Guid solutionId)
        {
            var features = await _features.GetAsync(id, solutionId.ToString());
            if (!features.Any())
                return NotFound();

            var featureEntity = features.First();
            return Ok(GetFeatureModel.FromEntity(featureEntity));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]FeatureModel featureModel, Guid solutionId)
        {
            var featureId = await _features.SaveAsync(featureModel.ToEntity(solutionId));
            return Created($"api/v1/solutions/{solutionId}/features/{featureId}", featureId);
        }
    }
}