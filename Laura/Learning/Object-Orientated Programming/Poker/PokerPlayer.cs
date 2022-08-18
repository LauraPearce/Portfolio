using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.CardClasses;

namespace Poker
{
    public class PokerPlayer
    {
        public bool HasFolded { get; private set; }
        
        //TODO: summary comment
        public string Name { get; set; } // players can change their name        

        private int _balance;

        //TODO: summary comment
        public int Balance
        {
            get { return _balance; }
            set
            {
                // stops if balance is less than zero
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(_balance), "The balance must be a positive integer.");
                }
                else
                {
                    // sets the balance 
                    _balance = value;
                }
            }
        }

        private List<Card> _holeCards; // hole cards cannot be added or changed once assigned, they are read only

        //TODO: summary comment
        public IReadOnlyCollection<Card> HoleCards
        {
            get { return _holeCards.AsReadOnly(); }
        }

        //TODO: summary comment
        //TODO: think about how to manage it being changed
        public int Position { get; set; }


        public PokerPlayer(string name, int balance)
        {
            Name = name;
            _holeCards = new List<Card>();
            Position = -1;
            Balance = balance;
            HasFolded = false;
        }

        //TODO: summary comment
        public Deck SetHoleCards(Deck deck)
        {
            _holeCards = deck.Draw(2);
            return deck;
        }

        //TODO: summary comment
        public override bool Equals(object? obj)
        {
            PokerPlayer player = obj as PokerPlayer;

            if (player == null)
            {
                return false;
            }

            if (Name == player.Name && Position == player.Position)
            {
                return true;
            }
            else
            {
                return false;
            }
               
        }

        //TODO: summary comment
        public HandCombinations GetHandValue(PokerGame game)
        {
            List<Card> hand = new List<Card>();
            HandCombinations handValue;

            // puts the hole cards and community cards into a single list         

            hand.AddRange(HoleCards);
            hand.AddRange(game.CommunityCards);

            // put the cards in numerical order
            hand = hand.OrderBy(o => o.Value).ToList();

            // initialise check variables
            int twoOfPair1 = 0;
            int twoOfPair2 = 0;
            int threeOf = 0;
            int fourOf = 0;
            
            bool flushCheck = true;
            int straightCheck = -1;

            // check for different hand criteria 
            for (int a = 0; a < hand.Count; a++)
            {
                int flushCounter = 1;
                int numberOfKind = 1;
                int currentCardFaceValue = ((int)hand[a].Value);
                CardSuit currentCardSuit = (hand[a].Suit);

                if (a == 0)
                {
                    // start with assuming you have a flush
                    flushCheck = true;

                    // start with assuming you have a straight
                    straightCheck = ((int)hand[a].Value);
                }

                for (int b = 0; b < hand.Count; b++)
                {
                    // dont check the card against itself
                    if (currentCardSuit != hand[b].Suit || currentCardFaceValue != ((int)hand[b].Value))
                    {
                        // if the card is the same value but is not the same suit (aka not the same card)
                        // increase number of a kind
                        if (currentCardFaceValue == ((int)hand[b].Value))
                        {
                            numberOfKind++;
                        }

                        // checks if suits match
                        if (currentCardSuit == hand[b].Suit)
                        {
                            flushCounter++;
                        }

                        if (flushCounter < 5)
                        {
                            flushCheck = false;
                        }
                        else
                        {
                            flushCheck = true;
                        }
                        // if value of next card -1 is the same as current value, continue to check for straight
                        if (a == 0)
                        {
                            if (straightCheck != -1 && straightCheck == ((int)hand[b].Value) - 1)
                            {
                                straightCheck++;
                            }
                            else
                            {
                                // if values are out of order set straight to -1
                                straightCheck = -1;
                            }
                        }
                    }
                }

                // mark how many of a kind we have for each value
                switch (numberOfKind)
                {
                    case 4:
                        fourOf = currentCardFaceValue;
                        break;
                    case 3:
                        threeOf = currentCardFaceValue;
                        break;
                    case 2:
                        // uses additional pair 2 variable to manage 2 pairs
                        if (twoOfPair1 == 0)
                        {
                            twoOfPair1 = currentCardFaceValue;
                        }
                        // check the pairs are not the same
                        else if (twoOfPair1 != currentCardFaceValue)
                        {
                            twoOfPair2 = currentCardFaceValue;
                        }
                        break;
                    default:
                        break;
                }
            }

            // evaluate criteria to determine highest card value
            bool royalFlush = (flushCheck != false && straightCheck >= 14);
            bool straightFlush = (flushCheck != false && straightCheck != -1);
            bool fourOfAKind = (fourOf != 0);
            bool fullHouse = (threeOf != 0 && twoOfPair1 != 0);
            bool flush = (flushCheck != false);
            bool straight = (straightCheck != -1);
            bool threeOfAKind = (threeOf != 0);
            bool twoPairs = (twoOfPair1 != 0 && twoOfPair2 != 0);
            bool pair = (twoOfPair1 != 0);

            if (royalFlush) { handValue = HandCombinations.RoyalFlush; }
            else if (straightFlush) { handValue = HandCombinations.StraightFlush; }
            else if (fourOfAKind) { handValue = HandCombinations.FourOfAKind; }
            else if (fullHouse) { handValue = HandCombinations.FullHouse; }
            else if (flush) { handValue = HandCombinations.Flush; }
            else if (straight) { handValue = HandCombinations.Straight; }
            else if (threeOfAKind) { handValue = HandCombinations.ThreeOfAKind; }
            else if (twoPairs) { handValue = HandCombinations.TwoPair; }
            else if (pair) { handValue = HandCombinations.Pair; }
            else { handValue = HandCombinations.HighCard; }

            return handValue;
        }

        //TODO: summary comment
        private void CheckPlayerCanMakeBet(int betAmount)
        {
            //TODO: add code comments for clarity
            if (Position == -1)
            {
                throw new ArgumentNullException(nameof(Name), "This player is not actively playing this round.");
            }

            if (HasFolded == true)
            {
                throw new ArgumentNullException(nameof(Name), "This player has folded in this round already.");
            }

            if (betAmount > Balance)
            {
                throw new ArgumentOutOfRangeException(nameof(Balance), "The player balance is smaller than the bet being placed.");
            }
        }

        //TODO: raise(), call() need to return the amount to alter the pot by to the PokerGame

        public void Raise(PokerGame game, int playerBet)
        {
            CheckPlayerCanMakeBet(game.MinimumBet + playerBet);

            // raises the minimum bet and checks balance is sufficient
            game.MinimumBet += playerBet;

            // takes bet from player balance and adds to the pot
            Balance -= game.MinimumBet;
            game.Pot += game.MinimumBet;
        }

        public void Fold(PokerGame game)
        {
            // player stop playing the round
            HasFolded = true;
            _holeCards.Clear();
        }

        public void Call(PokerGame game)
        {
            CheckPlayerCanMakeBet(game.MinimumBet);

            Balance -= game.MinimumBet;
            game.Pot += game.MinimumBet;
        }


    }
}
