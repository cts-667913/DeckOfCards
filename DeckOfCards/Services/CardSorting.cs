using DeckOfCards.CardModel;
using DeckOfCards.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards.Services
{
    public class CardSorting:RepositoryBase,ICardSorting
    {
        object returnValue = new object();
        public object ReturnAllCards()
        {
            try
            {
                List<string> allCards = new List<string>();


                allCards.Add("Ac");
                allCards.Add("2c");
                allCards.Add("3c");
                allCards.Add("4c");
                allCards.Add("5c");
                allCards.Add("6c");
                allCards.Add("7c");
                allCards.Add("8c");
                allCards.Add("9c");
                allCards.Add("10c");

                allCards.Add("Jc");
                allCards.Add("Qc");
                allCards.Add("Kc");

                allCards.Add("Ah");
                allCards.Add("2h");
                allCards.Add("3h");
                allCards.Add("4h");
                allCards.Add("5h");
                allCards.Add("6h");
                allCards.Add("7h");
                allCards.Add("8h");
                allCards.Add("9h");
                allCards.Add("10h");


                allCards.Add("Jh");
                allCards.Add("Qh");
                allCards.Add("Kh");

                allCards.Add("Ad");
                allCards.Add("2d");
                allCards.Add("3d");
                allCards.Add("4d");
                allCards.Add("5d");
                allCards.Add("6d");
                allCards.Add("7d");
                allCards.Add("8d");
                allCards.Add("9d");
                allCards.Add("10d");

                allCards.Add("Jd");
                allCards.Add("Qd");
                allCards.Add("Kd");

                allCards.Add("As");
                allCards.Add("2s");
                allCards.Add("3s");
                allCards.Add("4s");
                allCards.Add("5s");
                allCards.Add("6s");
                allCards.Add("7s");
                allCards.Add("8s");
                allCards.Add("9s");
                allCards.Add("10s");

                allCards.Add("Js");
                allCards.Add("Qs");
                allCards.Add("Ks");

                returnValue = allCards;
            }
            catch(Exception ex)
            {
                returnValue = GetCustomException(ex);
            }
            return returnValue;
        }

        public object ReturnDeck(List<Cards> inputCards)
        {
            object returnValue = new object();
            try
            {
                Dictionary<int, List<string>> cardDetailsDictionary = new Dictionary<int, List<string>>();
                List<Cards> resultCards = new List<Cards>();
                List<string> sortedDeck = new List<string>();
                int suitInt = 0;

                foreach (var item in inputCards)
                {
                    if (item.Suits == "d") suitInt = 1;
                    else if (item.Suits == "s") suitInt = 2;
                    else if (item.Suits == "c") suitInt = 3;
                    else if (item.Suits == "h") suitInt = 4;

                    if (!cardDetailsDictionary.ContainsKey(suitInt))
                    cardDetailsDictionary.Add(suitInt, new List<string>());
                    cardDetailsDictionary[suitInt].Add(item.Value);
                }

                foreach (KeyValuePair<int, List<string>> pair in cardDetailsDictionary.OrderBy(key => key.Key))
                {
                    ReturnCards addCards = new ReturnCards();
                    int returnValueNo = 0;
                    addCards.SuitReturn = pair.Key;
                    List<int> retunInt = new List<int>();
                    foreach (var item in pair.Value)
                    {
                        if (item == "J") returnValueNo = 11;
                        else if (item == "Q") returnValueNo = 12;
                        else if (item == "K") returnValueNo = 13;
                        else if (item == "A") returnValueNo = 14;
                        else
                        {
                            returnValueNo = int.Parse(item);
                        }
                        retunInt.Add(returnValueNo);
                    }
                    retunInt.Sort();

                    string finalSuit = null;

                    if (pair.Key == 1) finalSuit = "d";
                    else if (pair.Key == 2) finalSuit = "s";
                    else if (pair.Key == 3) finalSuit = "c";
                    else if (pair.Key == 4) finalSuit = "h";
                    foreach (var item in retunInt)
                    {
                        StringBuilder resultDeck = new StringBuilder();
                        if (item == 11) resultDeck.Append($"J{finalSuit}");
                        else if (item == 12) resultDeck.Append($"Q{finalSuit}");
                        else if (item == 13) resultDeck.Append($"K{finalSuit}");
                        else if (item == 14) resultDeck.Append($"A{finalSuit}");
                        else
                        {
                            resultDeck.Append($"{item}{finalSuit}");
                        }
                        sortedDeck.Add(resultDeck.ToString());
                    }
                    returnValue = sortedDeck;
                }
            }
            catch (Exception ex)
            {
                returnValue = GetCustomException(ex);
            }
            return returnValue;
        }
    }
}
