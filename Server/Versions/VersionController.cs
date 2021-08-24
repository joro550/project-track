﻿using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Track.Persistence;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Versions.Models;

namespace Project.Track.Server.Versions
{
    [ApiController]
    [Route("api/v1/solutions/{solutionId:guid}/versions")]
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
        public async Task<IActionResult> GetAsync(Guid solutionId)
        {
            var branchEntities = await _versions.GetAsync();
            return Ok(branchEntities.Select(GetVersionModel.FromEntity));
        }
        
        [HttpGet("id:guid")]
        public async Task<IActionResult> GetAsync(Guid id, Guid solutionId)
        {
            var versions = await _versions.GetAsync(id, solutionId.ToString());
            if (!versions.Any())
                return NotFound();

            var featureEntity = versions.First();
            return Ok(GetVersionModel.FromEntity(featureEntity));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]VersionModel featureModel, Guid solutionId)
        {
            var versionId = await _mediator.Send(featureModel.ToRequest(solutionId));
            return Created($"api/v1/solutions/{solutionId}/versions/{versionId}", versionId);
        }
    }
}