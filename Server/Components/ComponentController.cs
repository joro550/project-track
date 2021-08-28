using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Track.Persistence;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Components.Models;
using Project.Track.Shared.Components;

namespace Project.Track.Server.Components
{
    [ApiController]
    [Route("api/v1/solutions/{solutionId}/components")]
    public class ComponentController : ControllerBase
    {
        private readonly IRepository<ComponentEntity> _components;

        public ComponentController(IRepository<ComponentEntity> components) 
            => _components = components;

        [HttpGet]
        public async Task<IActionResult> GetAsync(string solutionId)
        {
            var componentEntities = await _components.GetAsync(parameters: solutionId);
            return Ok(componentEntities.Select(e => e.FromEntity()));
        }
        
        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(string id, string solutionId)
        {
            var componentEntities = await _components.GetAsync(id, solutionId);
            if (!componentEntities.Any())
                return NotFound();

            var card = componentEntities.First();
            return Ok(card.FromEntity());
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ComponentModel cardModel, string solutionId)
        {
            var componentEntity = cardModel.ToEntity(solutionId);
            var componentId = await _components.SaveAsync(componentEntity);
            return Created($"api/v1/solutions/{solutionId}/components/{componentId}", componentId);
        }
    }
}