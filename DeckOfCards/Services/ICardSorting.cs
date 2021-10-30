using DeckOfCards.CardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfCards.Services
{
    public interface ICardSorting
    {
        object ReturnDeck(List<Cards> inputCards);
        object ReturnAllCards();
    }
}
