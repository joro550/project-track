using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Track.Persistence;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Components.Models;

namespace Project.Track.Server.Components
{
    [ApiController]
    [Route("api/v1/solutions/{solutionId:guid}/components")]
    public class ComponentController : ControllerBase
    {
        private readonly IRepository<ComponentEntity> _components;

        public ComponentController(IRepository<ComponentEntity> components) 
            => _components = components;

        [HttpGet]
        public async Task<IActionResult> GetAsync(Guid solutionId)
        {
            var componentEntities = await _components.GetAsync();
            return Ok(componentEntities.Select(GetComponentModel.FromEntity));
        }
        
        [HttpGet("id:guid")]
        public async Task<IActionResult> GetAsync(Guid id, Guid solutionId)
        {
            var componentEntities = await _components.GetAsync(id, solutionId.ToString());
            if (!componentEntities.Any())
                return NotFound();

            var card = componentEntities.First();
            return Ok(GetComponentModel.FromEntity(card));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ComponentModel cardModel, Guid solutionId)
        {
            var componentEntity = cardModel.ToEntity(solutionId);
            var componentId = await _components.SaveAsync(componentEntity);
            return Created($"api/v1/solutions/{solutionId}/components/{componentId}", componentId);
        }
    }
}