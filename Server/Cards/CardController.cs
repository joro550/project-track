using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Track.Persistence;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Cards.Models;

namespace Project.Track.Server.Cards
{
    [ApiController]
    [Route("api/v1/solutions/{solutionId:guid}/cards")]
    public class CardController : ControllerBase
    {
        private readonly IRepository<CardEntity> _cards;

        public CardController(IRepository<CardEntity> cards) 
            => _cards = cards;

        [HttpGet]
        public async Task<IActionResult> GetAsync(Guid solutionId)
        {
            var cardEntities = await _cards.GetAsync();
            return Ok(cardEntities.Select(GetCardModel.FromEntity));
        }

        [HttpGet("id:guid")]
        public async Task<IActionResult> GetAsync(Guid id, Guid solutionId)
        {
            var cardEntities = await _cards.GetAsync(id, solutionId.ToString());
            if (!cardEntities.Any())
                return NotFound();

            var card = cardEntities.First();
            return Ok(GetCardModel.FromEntity(card));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]CardModel cardModel, Guid solutionId)
        {
            var branchEntity = cardModel.ToEntity(solutionId);
            var cardId = await _cards.SaveAsync(branchEntity);
            return Created($"api/v1/solutions/{solutionId}/cards/{cardId}", cardId);
        }
    }
}