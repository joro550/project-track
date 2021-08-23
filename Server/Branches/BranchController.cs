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
    [Route("api/v1/solutions/{solutionId:guid}/branches")]
    public class BranchController : ControllerBase
    {
        private readonly IRepository<BranchEntity> _branches;

        public BranchController(IRepository<BranchEntity> branches) 
            => _branches = branches;

        [HttpGet]
        public async Task<IActionResult> GetAsync(Guid solutionId) 
            => Ok(await _branches.GetAsync());

        [HttpGet("id:guid")]
        public async Task<IActionResult> GetAsync(Guid id, Guid solutionId)
        {
            var branch = await _branches.GetAsync(id, solutionId.ToString());
            if (!branch.Any())
                return NotFound();
            return Ok(branch.First());
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]Branch branch, Guid solutionId)
        {
            await _branches.SaveAsync(branch.ToBranch());
            return Created($"api/v1/solutions/{branch.Id}", branch);
        }
    }
}