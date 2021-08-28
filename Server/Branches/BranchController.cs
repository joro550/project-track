using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Track.Persistence;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Branches.Models;

namespace Project.Track.Server.Branches
{
    [ApiController]
    [Route("api/v1/solutions/{solutionId}/branches")]
    public class BranchController : ControllerBase
    {
        private readonly IRepository<BranchEntity> _branches;

        public BranchController(IRepository<BranchEntity> branches) 
            => _branches = branches;

        [HttpGet]
        public async Task<IActionResult> GetAsync(string solutionId)
        {
            var branchEntities = await _branches.GetAsync(parameters: solutionId);
            return Ok(branchEntities.Select(GetBranchModel.FromEntity));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(string id, string solutionId)
        {
            var branch = await _branches.GetAsync(id, solutionId);
            if (!branch.Any())
                return NotFound();

            var branchEntity = branch.First();
            return Ok(GetBranchModel.FromEntity(branchEntity));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]BranchModel getBranchModel, string solutionId)
        {
            var branches = await _branches.GetAsync(parameters: solutionId);
            var defaultBranch = branches.FirstOrDefault(entity => entity.IsDefault);
            if (defaultBranch is null)
                return StatusCode(500);

            var branchEntity = getBranchModel.ToBranch(defaultBranch.Id, solutionId);
            var branchId = await _branches.SaveAsync(branchEntity);
            return Created($"api/v1/solutions/{solutionId}/branches/{branchId}", branchId);
        }
        
        [HttpDelete("id:guid")]
        public async Task<IActionResult> CreateAsync(string solutionId, string id)
        {
            var branches = await _branches.GetAsync(id, solutionId);
            var defaultBranch = branches.FirstOrDefault(entity => entity.IsDefault);
            if (defaultBranch is null)
                return BadRequest("cannot_delete_default_branch");

            return NoContent();
        }
    }
}