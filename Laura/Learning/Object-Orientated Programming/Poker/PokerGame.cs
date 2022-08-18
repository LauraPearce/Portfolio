using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.CardClasses;

namespace Poker
{
    public class PokerGame
    {
        private Deck _deck;

        private bool _isRoundInPlay;

        private List<PokerPlayer> _players;
        //TODO: summary comment
        public IReadOnlyCollection<PokerPlayer> Players
        {
            get { return _players.AsReadOnly(); }
        }

        //TODO: summary comment
        public IReadOnlyCollection<PokerPlayer> ActivePlayers
        {
            get
            {
                List<PokerPlayer> activePlayers = new List<PokerPlayer> ();
                foreach (var player in Players)
                {
                    if (player.Position != -1 && player.HasFolded == false)
                    {
                        activePlayers.Add (player);
                    }
                }
                return activePlayers.OrderBy(p => p.Position).ToList().AsReadOnly();
            }
        }

        //TODO: summary comment
        public IReadOnlyCollection<PokerPlayer> InactivePlayers
        {
            get
            {
                List<PokerPlayer> inactivePlayers = new List<PokerPlayer>();
                foreach (var player in Players)
                {
                    if (player.Position == -1 || player.HasFolded == true)
                    {
                        inactivePlayers.Add(player);
                    }
                }
                return inactivePlayers.AsReadOnly();
            }
        }

        //TODO: pot access modifiers - private set + changes to raise() and call()
        //TODO: summary comment
        public int Pot { get; set; }

        //TODO: summary comment
        public int SmallBlind
        {
            // validated within big blind
            get
            {
                return _bigBlind / 2;
            }   
        }
        
        //TODO: think about changing access modifiers
        //TODO: summary comment
        public int MinimumBet { get; set; }
        
        private int _bigBlind;

        //TODO: summary comment
        public int BigBlind
        {
            get { return _bigBlind; }
            private set
            {
                // stops if big blind is too small or an even number
                if ((value % 2 != 0) || (value < 2))
                {
                    throw new ArgumentOutOfRangeException(nameof(_bigBlind), "The big blind must be greater than 2 and even integer.");
                }
                else
                {
                    // sets the balance 
                    _bigBlind = value;
                    
                }
            }
        }
        /// <summary>
        /// contains cards on the table - flop, river and turn
        /// </summary>
        private List<Card> _communityCards;
        public IReadOnlyCollection<Card> CommunityCards
        {
            get
            {
                return _communityCards.AsReadOnly();
            }
        }

        public PokerGame(int bigBlind)
        {
            _players = new List<PokerPlayer>();
            _deck = new Deck();
            _isRoundInPlay = false;
            _bigBlind = bigBlind; 
            _communityCards = new List<Card>();
        }

        //TODO: summary comment
        public List<PokerPlayer> Deal()
        {
            SetPositionOfPlayers();
            
            // gives each player two cards in their hand
            foreach (PokerPlayer player in Players)
            {
               _deck = player.SetHoleCards(_deck);
            }
                     
            return _players;
        }

        //TODO: summary comment
        public void PlayerJoin(PokerPlayer playerJoining)
        {
            _players.Add(playerJoining);
        }

        //TODO: summary comment
        public void PlayerJoin(List<PokerPlayer> listOfNewPlayers)
        {
            _players.AddRange(listOfNewPlayers);
        }

        //TODO: summary comment
        public void PlayerLeave(PokerPlayer playerLeaving)
        {
            if (_isRoundInPlay == true)
            {
                throw new Exception("Round is in play, cannot leave part way through.");
            }

            bool playerFound = false;
             
            // checks if the player trying to leave is in the list of players
            foreach (PokerPlayer player in _players)
            {
               if (player.Equals(playerLeaving))
               {
                    playerFound = true;
               }
            }

            if (playerFound == true)
            {
                // if player is an active player
                if (playerLeaving.Position != -1)
                {
                    foreach (PokerPlayer player in ActivePlayers)
                    {
                        // for anyone with a larger position number
                        if (player.Position > playerLeaving.Position)
                        {
                            // take one off of their position number due to player leaving
                            player.Position--;
                        }
                    }
                }
                playerLeaving.Position = -1;               
                _players.Remove(playerLeaving);
            }
            else
            {
                throw new ArgumentNullException(nameof(playerLeaving), "Player leaving is not in the list.");
            }
           
        }

        //TODO: summary comment
        //TODO: remove or change StartRound()
        public void StartRound()
        {
            // stops if players dont have the balance to put down the small blind
            foreach (PokerPlayer player in Players)
            {
                if (player.Balance < SmallBlind)
                {
                    //TODO: consider removing player and continuing 
                    throw new ArgumentOutOfRangeException(nameof(player.Balance), "Player balance is smaller than the small blind.");
                }
            }

            MinimumBet = BigBlind;
            SetPositionOfPlayers();
            _isRoundInPlay = true;
        }

        //TODO: remove or change EndRound()
        //TODO: change pot empty
        public void EndRound()
        {
            _isRoundInPlay = false;
            Pot = 0;
        }

        //TODO: summary comment
        public void SetPositionOfPlayers()
        {
            if (_isRoundInPlay == true)
            {
                throw new Exception("Round is in play, position cannot be set part way through.");
            }

            bool doAllPlayersNeedNewPosition = true;
            // checks if all players have a position number of -1
            foreach (PokerPlayer player in Players)
            {
                if (player.Position != -1)
                {
                    doAllPlayersNeedNewPosition = false;
                }
                
            }

            // if game is beginning or all players are new, sets all players a new position number
            if (doAllPlayersNeedNewPosition == true)
            {
                int positionCounter = 0;
                foreach (PokerPlayer player in Players)
                {
                    player.Position = positionCounter;
                    positionCounter++;
                }
            }
            // if game has already started
            else
            {
                // the position button for active players is moved around each time.
                foreach (PokerPlayer player in ActivePlayers)
                {
                    //if the player is active, move their position                   
                    if (player.Position == ActivePlayers.Count-1)
                    {
                        player.Position = 0;
                    }
                    else if (player.Position < ActivePlayers.Count)
                    {
                        player.Position++;
                    }    
                    
                }
                
                // adds position numbers for new players
                int positionCounter = ActivePlayers.Count;
                foreach (PokerPlayer player in InactivePlayers)
                {
                    player.Position = positionCounter;
                    positionCounter++;
                }
            }
                   
        }

        /// <summary>
        /// takes the small and big blind from the players at the start of the round
        /// </summary>
        public void TakeBlinds()
        {
            foreach (PokerPlayer player in ActivePlayers)
            {
                switch (player.Position)
                {
                    // player in position one puts the small blind down
                    case 1:
                    {
                        player.Balance -= SmallBlind;
                        Pot += SmallBlind;
                        break;
                    }
                    // player in position 2 puts the big blind down
                    case 2:
                    {
                        player.Balance -= BigBlind;
                        Pot += BigBlind;
                        MinimumBet = BigBlind;
                        break;
                    }
                    default:
                        break;
                }
            }
        }

        private void CheckNumberOfCommunityCards()
        {
            if (_communityCards.Count > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(_communityCards), "Only 5 cards can be on the table");
            }
        }

        /// <summary>
        /// draws three cards for the table and adds to the community cards
        /// </summary>
        public void Flop()
        {
            CheckNumberOfCommunityCards();
            _communityCards = _deck.Draw(3);
        }

        /// <summary>
        /// draws one card for the table and adds to the community cards
        /// </summary>
        public void TurnOrRiver()
        {
            CheckNumberOfCommunityCards();
            _communityCards.AddRange((_deck.Draw(1)));
        }

       


    }
}
