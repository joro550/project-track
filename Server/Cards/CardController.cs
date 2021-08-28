using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Track.Persistence;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Cards.Models;
using Project.Track.Shared.Cards;

namespace Project.Track.Server.Cards
{
    [ApiController]
    [Route("api/v1/solutions/{solutionId}/cards")]
    public class CardController : ControllerBase
    {
        private readonly IRepository<CardEntity> _cards;

        public CardController(IRepository<CardEntity> cards) 
            => _cards = cards;

        [HttpGet]
        public async Task<IActionResult> GetAsync(string solutionId)
        {
            var cardEntities = await _cards.GetAsync(parameters: solutionId);
            return Ok(cardEntities.Select(e => e.ToModel()));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(string id, string solutionId)
        {
            var cardEntities = await _cards.GetAsync(id, solutionId);
            if (!cardEntities.Any())
                return NotFound();

            var card = cardEntities.First();
            return Ok(card.ToModel());
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]CardModel cardModel, string solutionId)
        {
            var branchEntity = cardModel.ToEntity(solutionId);
            var cardId = await _cards.SaveAsync(branchEntity);
            return Created($"api/v1/solutions/{solutionId}/cards/{cardId}", cardId);
        }
    }
}