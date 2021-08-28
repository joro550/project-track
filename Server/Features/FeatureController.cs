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
    [Route("api/v1/solutions/{solutionId}/features")]
    public class FeatureController : ControllerBase
    {
        private readonly IRepository<FeatureEntity> _features;

        public FeatureController(IRepository<FeatureEntity> features) 
            => _features = features;
        
        [HttpGet]
        public async Task<IActionResult> GetAsync(string solutionId)
        {
            var branchEntities = await _features.GetAsync(parameters: solutionId);
            return Ok(branchEntities.Select(GetFeatureModel.FromEntity));
        }
        
        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(string id, string solutionId)
        {
            var features = await _features.GetAsync(id, solutionId);
            if (!features.Any())
                return NotFound();

            var featureEntity = features.First();
            return Ok(GetFeatureModel.FromEntity(featureEntity));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]FeatureModel featureModel, string solutionId)
        {
            var featureId = await _features.SaveAsync(featureModel.ToEntity(solutionId));
            return Created($"api/v1/solutions/{solutionId}/features/{featureId}", featureId);
        }
    }
}