using DeckOfCards.CardModel;
using DeckOfCards.Services;
using DeckOfCards.Services.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfCards.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly ICardSorting _cardSorting;


        public CardsController(ICardSorting cardSorting)
        {
            _cardSorting = cardSorting;
        }

        [HttpPost("sortedCards")]
        public object GetSortedCards([FromBody] string [] selectedCards)
        {

            List<String> deckOfCards = new List<String>(selectedCards);
            List<Cards> cards = new List<Cards>();
            foreach (var item in deckOfCards)
            {
                Cards valueCard = new Cards();
                valueCard.Suits = item.Substring(item.Length - 1);
                valueCard.Value = item.Remove(item.Length - 1, 1);
                cards.Add(valueCard);
            }

            var result=  _cardSorting.ReturnDeck(cards);
            if(result is CustomException ce)
            {
                return new ObjectResult(ce.ErrorMessage) { StatusCode = (int)ce.StatusCode };
            }
            return new OkObjectResult(result);
        }
        [HttpGet("getAllCards")]
        public object GetAllCards()
        {
            var result= _cardSorting.ReturnAllCards();
            if(result is CustomException ce)
            {
                return new ObjectResult(ce.ErrorMessage) { StatusCode = (int)ce.StatusCode };
            }
            return new OkObjectResult(result);
        }
    }
}
