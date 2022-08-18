using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.CardClasses
{
    public class Card
    {
        public CardValue Value { get; private set; }

        public CardSuit Suit { get; private set; }
        
        /// <summary>
        /// creates a card
        /// </summary>
        /// <param name="suit">sets the card suit</param>
        /// <param name="value">sets the card value</param>
        public Card(CardSuit suit, CardValue value)
        {
            Value = value;
            Suit = suit;
        }

        /// <summary>
        /// puts together the name of the card
        /// </summary>
        /// <returns>the name of the card</returns>
        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }

        /// <summary>
        /// compares cards to see if they are the sasme
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>if the cards are matching, true</returns>
        public override bool Equals(object? obj)
        {
            Card card = obj as Card;

            if (obj == null)
            {
                return false;
            }

            if (Suit == card.Suit &&
                Value == card.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
            
            
        }
    }
}
