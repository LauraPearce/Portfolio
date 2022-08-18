using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.CardClasses;

namespace Poker
{
    public class Deck
    {
        private List<Card> _cards;

        //TODO: summary comment
        public IReadOnlyCollection<Card> Cards
        {
            get { return _cards.AsReadOnly(); }
        }

        public Deck()
        {
            _cards = new List<Card>();
            Reset();
        }

        //TODO: summary comment
        private void Reset()
        {
            for (int i = 0; i < Enum.GetNames(typeof(CardSuit)).Length; i++)
            {
                for (int b = 2; b <= Enum.GetNames(typeof(CardValue)).Length + 1; b++)
                {
                    Card newCard = new Card((CardSuit)i, (CardValue)b);
                    _cards.Add(newCard);
                }

            }
            
            Extensions.Shuffle(_cards);
        }

        /// <summary>
        /// draws a number of cards from the top of the deck
        /// </summary>
        /// <param name="howManyCards">number of cards to be drawn</param>
        /// <param name="Cards">deck of cards</param>
        /// <returns>list of drawn cards</returns>
        public List<Card> Draw(int howManyCards)
        { 
            if (howManyCards > _cards.Count)
            {
                throw new ArgumentOutOfRangeException("There are not enough cards left in the deck to draw this amount."); 

            }

            List<Card> cardsDrawn = new List<Card>();
            
            for (int i = howManyCards-1; i >= 0 ; i--)
            {
                cardsDrawn.Add(_cards[i]);
                _cards.RemoveAt(i);
            }

            return cardsDrawn;
        
        }

    }
}
