using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.CardClasses;
using Poker;

namespace ConsoleForTesting
{
    public class OOPPokerConsole
    {
        public static void DisplayPokerPlayerPositions(IReadOnlyCollection<PokerPlayer> players)
        {
            // displays the players and their position
            Console.WriteLine("The players and their position in the game are...");

            foreach (PokerPlayer player in players)
            {
                Console.Write(player.Name);
                Console.WriteLine($" {player.Position}");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void DisplayPokerPlayerBalances(IReadOnlyCollection<PokerPlayer> players)
        {
            // displays remaining balances of players after blinds taken
            foreach (PokerPlayer player in players)
            {
                Console.WriteLine($"{player.Name} is in position {player.Position} and has {player.Balance} left.");
            }
        }

        public static void Run()
        {

            // hardcoded cards
            Card aceHearts = new Card(CardSuit.Hearts, CardValue.Ace);
            aceHearts.ToString();
            Console.WriteLine($"A card is... {aceHearts}.");

            Card fourClubs = new Card(CardSuit.Clubs, CardValue.Four);
            fourClubs.ToString();
            Console.WriteLine($"Another card is... {fourClubs}");

            Card aceHeartsTwo = new Card(CardSuit.Hearts, CardValue.Ace);
            aceHeartsTwo.ToString();
            Console.WriteLine($"A third card is... {aceHeartsTwo}");
            Console.WriteLine();

            // tests if the hardcoded cards above are the same
            Console.WriteLine($"Is card one the same as card two? {aceHearts.Equals(fourClubs)}");
            Console.WriteLine($"Is card one the same as card three? {aceHearts.Equals(aceHeartsTwo)}");
            Console.WriteLine();
         
            // creates a new deck
            Deck myDeck = new Deck();

            // displays each card in the deck
            Console.WriteLine("A shuffled deck of cards...");
            foreach (Card card in myDeck.Cards)
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine();
            Console.WriteLine();

            // draw two cards and display them
            List<Card> drawnCards = myDeck.Draw(10);
            
            Console.WriteLine("Drawn cards...");

            foreach (Card card in drawnCards)
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine();
            Console.WriteLine();

            // displays the cards left in the deck after some have been drawn

            Console.WriteLine("Cards left in deck...");

            foreach (Card card in myDeck.Cards)
            {
                Console.WriteLine(card.ToString());
            }
            
            // new game of poker 
            PokerGame gameOne = new PokerGame(50);

            // hardcoded players for testing
            PokerPlayer playerOne = new PokerPlayer("Mary", 1000);
            PokerPlayer playerTwo = new PokerPlayer("Gerry", 1000);
            PokerPlayer playerThree = new PokerPlayer("Tom", 1000);
            PokerPlayer playerFour = new PokerPlayer("Susan", 1000);
            PokerPlayer playerFive = new PokerPlayer("Nancy", 1000);

            // adds individual players to a list
            List<PokerPlayer> myPlayers = new List<PokerPlayer> { playerOne, playerTwo, playerThree, playerFour, playerFive };
            gameOne.PlayerJoin(myPlayers);
            Console.WriteLine();

            // should all be -1
            DisplayPokerPlayerPositions(gameOne.Players);
            Console.WriteLine("Brand new game started... Round 1!");

            // deals two cards to each player and sets the position of players at the beginning of a game
            gameOne.Deal();
            Console.WriteLine();
            Console.WriteLine($"Number of hole cards held by playerOne is {gameOne.Players.First().HoleCards.Count}.");
            Console.WriteLine();
            Console.WriteLine();                  

            // should be everyone included and ordered
            DisplayPokerPlayerPositions(gameOne.Players);
            gameOne.EndRound();

            gameOne.StartRound();
            // everyone goes up by 1
            DisplayPokerPlayerPositions(gameOne.Players);

            // adds a new player to the table mid-way through
            PokerPlayer playerSix = new PokerPlayer("Ronald", 100);
            gameOne.PlayerJoin(playerSix);
            Console.WriteLine();
            Console.WriteLine($"{playerSix.Name} has joined the game.");
            Console.WriteLine();

            // everything is the same except Ronald is -1
            DisplayPokerPlayerPositions(gameOne.Players);
            gameOne.EndRound();

            gameOne.StartRound();
            // Ronald should be included
            DisplayPokerPlayerPositions(gameOne.Players);
            gameOne.EndRound();

            // removes a player
            gameOne.PlayerLeave(playerFour);
            Console.WriteLine($"{playerFour.Name} has left the game.");
            
            gameOne.StartRound();
            // Susan should be removed
            DisplayPokerPlayerPositions(gameOne.Players);
            gameOne.EndRound();

            // displays the position of one player throughout the game
            for (int i = 0; i < gameOne.Players.Count; i++)
            {
                gameOne.StartRound();
                Console.WriteLine($"The position of playerThree is {playerThree.Position}.");
                gameOne.EndRound();
            }

            Console.WriteLine();
            Console.WriteLine();

            // hardcodes the value of the big blind for testing
            Console.WriteLine($"The value of the big blind is {gameOne.BigBlind}.");
            Console.WriteLine($"The value of the small blind is {gameOne.SmallBlind}.");

            Console.WriteLine();
            Console.WriteLine();

            // small and big blind taken and added to pot
            gameOne.TakeBlinds();
            Console.WriteLine($"The amount in the pot is {gameOne.Pot}");

            // player balances displayed 
            DisplayPokerPlayerBalances(gameOne.ActivePlayers);
            Console.WriteLine();
            Console.WriteLine();

            // three cards for flop drawn
            gameOne.Flop();
            Console.WriteLine("The Flop cards are...");

            // flop displayed
            foreach (Card card in gameOne.CommunityCards)
            {
                Console.WriteLine(card);
            }

            // one card for turn drawn and displayed
            gameOne.TurnOrRiver();
            Console.WriteLine($"The Turn card is...{gameOne.CommunityCards.Last()}");

            // one card for river drawn and displayed
            gameOne.TurnOrRiver();
            Console.WriteLine($"The River card is...{gameOne.CommunityCards.Last()}");

            Console.WriteLine();
            Console.WriteLine();

            HandCombinations handValue;
            handValue = playerOne.GetHandValue(gameOne);
            
            Console.WriteLine($"The best hand that {playerOne.Name} has is {handValue}");

            // testing for GetHandValue
            PokerGame gameForTesting = new PokerGame(50);
            PokerPlayer testPlayer = new PokerPlayer("Test", 100);
            gameForTesting.PlayerJoin(testPlayer);
            handValue = testPlayer.GetHandValue(gameForTesting);
            Console.WriteLine();
            Console.WriteLine($"The best hand that can be made is {handValue}");

            Console.WriteLine();
            Console.WriteLine($"The current minimum bet is {gameOne.MinimumBet}.");
            playerThree.Raise(gameOne, 25);
            Console.WriteLine($"{playerThree.Name} has raised. The pot now contains {gameOne.Pot}, {playerThree.Name}'s balance is now {playerThree.Balance} and the minimum bet is {gameOne.MinimumBet}.");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"The current minimum bet is {gameOne.MinimumBet}.");
            playerFive.Call(gameOne);
            Console.WriteLine($"{playerFive.Name} has called. The pot now contains {gameOne.Pot}, {playerFive.Name}'s balance is now {playerFive.Balance} and the minimum bet is {gameOne.MinimumBet}.");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"The current minimum bet is {gameOne.MinimumBet}.");
            playerSix.Fold(gameOne);
            Console.WriteLine($"{playerSix.Name} has folded. The pot now contains {gameOne.Pot} and the number of hole cards they hold is {playerSix.HoleCards.Count}.");

            //Susan shouldn't be able to fold, call or raise because she's not an active player.
            //playerFour.Raise(gameOne, 25);
            //playerFour.Call(gameOne);
            //playerFour.Fold(gameOne);

        }
    }
}
