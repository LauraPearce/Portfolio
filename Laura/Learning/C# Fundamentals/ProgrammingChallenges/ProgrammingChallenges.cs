using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ProgrammingChallenges
{
    public static class ProgrammingChallengesAnswers
    {
        public static List<int> FindTheSmallestAndBiggestNumbers(List<int> allNumbers)
        {
            
            int biggestNumber = allNumbers.Max();
            int smallestNumber = allNumbers.Min();

            // puts the biggest and smallest numbers into the result list
            List<int> result = new List<int>() { smallestNumber, biggestNumber };

            return result;
        }

        public static string HackerSpeak(string text)
        {
           // replaces letters with hacker speak numbers
            string convertedText = text.Replace("a", "4")
                .Replace("e", "3")
                .Replace("i", "1")
                .Replace("o", "0")
                .Replace("s", "5");

            return convertedText;
        }

        public static int HowManyDs(string text)
        {
            char lowerCaseD = 'd';
            char upperCaseD = 'D';

            // counts the number of letter ds in the text
            int numberOfLowerCaseDs = text.Count(f => (f == lowerCaseD));
            int numberOfUpperCaseDs = text.Count(f => (f == upperCaseD));
            int result = numberOfLowerCaseDs + numberOfUpperCaseDs;

            return result;
        }

        public static string FizzBuzzInterviewQuestion(int number)
        {
            // divide the number by three and five and get the remainder
            int remainder1 = number % 3;
            int remainder2 = number % 5;
            string result = null;

            // use a switch to look at the remainders to see if the number is a multiple of three or five or not
            switch (remainder1, remainder2)
            {
                // if number is a multiple of 3 AND 5
                case (0, 0):
                    result = "FizzBuzz";
                    break;                

                // if number is a multiple of 3 NOT 5
                case (0, > 0):                    
                    result = "Fizz";
                    break;                    

                // if number is a multiple of 5 NOT 3
                case ( > 0, 0):                    
                    result = "Buzz";
                    break;                    

                // if a number is not a multiple of 3 or 5, it is left to default and return the original number
                default:                    
                    result = number.ToString();
                    break;                 
            }
            return result;
        }

        public static StreamWriter CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter file = File.CreateText(path))
                {
                    file.WriteLine("Hello");
                }
            }
            return new StreamWriter(path);
        }

        public static double AmongUsImposterFormula(double player, double imposter)
        {
            // calculates the chances of being an imposter and stores the result
            double result = (100 * (imposter / player));

            // rounds the result to two decimal places
            result = Math.Round(result, 2, MidpointRounding.AwayFromZero);

            return result;
        }

        public static string AtmPinCodeLengthValidation(string pin)
        {
            // cuts spaces before and after the user input
            pin = pin.Trim();

            int pinLength = pin.Length;

            string result = null;

            // switch checks if the length of the pin is correct
            switch (pinLength)
            {
                // if pin field was empty
                case 0:
                    {
                        result = "The PIN field is empty. Please try again";
                        break;
                    }

                // if pin was less than 4 characters
                case < 4:
                    {
                        result = "The PIN entered was too short. Please try again";
                        break;
                    }

                // if pin is 4 characters
                case 4:
                    {
                        // sends the pin to a method which checks if it is only numbers
                        bool response = AtmPinCodeCharValidation(pin);

                        if (response == true)
                        {
                            result = "Thank-you for entering a correct PIN.";
                        }
                        else
                        {
                            result = "Only numbers are accepted. Please try again.";
                        }
                        break;
                    }

                // if pin is 5 characters
                case 5:
                    {
                        result = "The PIN entered was not the right length. Please try again";
                        break;
                    }

                // if pin is 6 characters
                case 6:
                    {
                        // sends the pin to a method which checks if it is all numbers
                        bool response = AtmPinCodeCharValidation(pin);

                        if (response == true)
                        {
                            result = "Thank-you for entering a correct PIN.";
                        }
                        else
                        {
                            result = "Only numbers are accepted. Please try again.";
                        }

                        break;
                    }

                // if pin is more than 6 characters
                case > 6:
                    {
                        result = "The PIN entered was too long. Please try again.";
                        break;
                    }
            }

            return result;
        }


        public static bool AtmPinCodeCharValidation(string pin)
        {
            // checks each character of the pin to make sure that they are digits only
            foreach (char c in pin)
            {
                if (!Char.IsDigit(c))
                {
                    return false; 
                } 
            }

            return true;
        }

        public static bool StringCharCheck(string number)
        {
            // checks each character to see if it is a number
            foreach (char c in number)
            {
                if (Char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static string StringLengthCheck(string number)
        {
            int length = number.Length;
            string result = null;

            // checks that the length of the phone number entered is correct
            if (length != 14)
            {
                result = "The phone number entered is the wrong length. Please try again.";
                return result;
            }
            else
            {
                return number;
            }
        }

        public static string IsThePhoneNumberFormattedCorrectly(string number)
        {
            //puts characters from string into array
            char[] numbers = number.ToCharArray(0, 14);

            // assigns variables to the special characters within the array
            char firstBracket = numbers[0];
            char secondBracket = numbers[4];
            char dash = numbers[9];

            string result = null;

            // checks if the special characters are in the right place
            if (firstBracket == '(' &&
                char.IsNumber(numbers[1]) &&
                char.IsNumber(numbers[2]) &&
                char.IsNumber(numbers[3]) &&
                secondBracket == ')' &&
                char.IsWhiteSpace(numbers[5]) &&
                char.IsNumber(numbers[6]) &&
                char.IsNumber(numbers[7]) &&
                char.IsNumber(numbers[8]) &&
                dash == '-' &&
                char.IsNumber(numbers[10]) &&
                char.IsNumber(numbers[11]) &&
                char.IsNumber(numbers[12]) &&
                char.IsNumber(numbers[13]))
            {
                result = "Thank-you, the phone number has been entered correctly.";
                return result;
            }
            else
            {
                result = "The phone number is not formatted correctly. Please try again.";
                return result;
            }
        }

        public static string CheckIfANumberIsPrime(int number)
        {
            string result = "Please try again.";

            // divides the number by all possible divisors 
            for (int i = 2; i < number; i++)
            {
                int remainder = number % i;
                
                // checks if the remainder is zero and therefore the number is not prime
                if (remainder == 0)
                {
                    result = $"Your number is not a prime number as it is divisible by {i}.";
                }
                else
                {
                    result = "Your number is a prime number.";                    
                }
            }            
            return result;
        }


        public static string[] PictureCardsToNumberEquivalent(string[] hand)
        {
            // changes picture cards into a numerical equivalent aka jack becomes 11

            // searches for picture cards and stores them in their own arrays
            string[] searchForQueen = Array.FindAll(hand, ele => ele.StartsWith('Q'));
            string[] searchForKing = Array.FindAll(hand, ele => ele.StartsWith('K'));
            string[] searchForJack = Array.FindAll(hand, ele => ele.StartsWith('J'));
            string[] searchForAce = Array.FindAll(hand, ele => ele.StartsWith('A'));

            string[] numericalHand = new string[5];

            // replaces all of the Js for Jack with 11
            for (int i = 0; i < hand.Count(); i++)
            {
                hand[i] = hand[i].Replace("J", "11");
            }

            // replaces all of the Qs for Queen with 12
            for (int i = 0; i < hand.Count(); i++)
            {
                hand[i] = hand[i].Replace("Q", "12");
            }

            // replaces all of the Ks for King with 13
            for (int i = 0; i < hand.Count(); i++)
            {
                hand[i] = hand[i].Replace("K", "13");
            }

            // replaces all pf the As for Ace with 14
            for (int i = 0; i < hand.Count(); i++)
            {
                hand[i] = hand[i].Replace("A", "14");
            }

            return hand;
        }

        public static List<int> OrderedCardValues(string[] numericalHand)
        {
            List<int> orderedNumericalCardValues = new List<int> { };

            string cardOneValue = null;
            string cardTwoValue = null;
            string cardThreeValue = null;
            string cardFourValue = null;
            string cardFiveValue = null;

            // puts the hand array into strings
            string cardOne = numericalHand[0];
            string cardTwo = numericalHand[1];
            string cardThree = numericalHand[2];
            string cardFour = numericalHand[3];
            string cardFive = numericalHand[4];

            // splits the first card value and first card suit into different strings
            if (cardOne.Length > 2)
            {
                cardOneValue = ($"{cardOne[0]}{cardOne[1]}");
                string cardOneSuit = ($"{cardOne[2]}");
            }
            else
            {
                cardOneValue = ($"{cardOne[0]}");
                string cardOneSuit = ($"{cardOne[1]}");
            }

            // splits the second card value and second card suit into different strings
            if (cardTwo.Length > 2)
            {
                cardTwoValue = ($"{cardTwo[0]}{cardTwo[1]}");
                string cardTwoSuit = ($"{cardTwo[2]}");
            }
            else
            {
                cardTwoValue = ($"{cardTwo[0]}");
                string cardTwoSuit = ($"{cardTwo[1]}");
            }

            // splits the third card value and third card suit into different strings
            if (cardThree.Length > 2)
            {
                cardThreeValue = ($"{cardThree[0]}{cardThree[1]}");
                string cardThreeSuit = ($"{cardThree[2]}");
            }
            else
            {
                cardThreeValue = ($"{cardThree[0]}");
                string cardThreeSuit = ($"{cardThree[1]}");
            }

            // splits the fourth card value and fourth card suit into different strings
            if (cardFour.Length > 2)
            {
                cardFourValue = ($"{cardFour[0]}{cardFour[1]}");
                string cardFourSuit = ($"{cardFour[2]}");
            }
            else
            {
                cardFourValue = ($"{cardFour[0]}");
                string cardFourSuit = ($"{cardFour[1]}");
            }

            // splits the fifth card value and fifth card suit into different strings
            if (cardFive.Length > 2)
            {
                cardFiveValue = ($"{cardFive[0]}{cardFive[1]}");
                string cardFiveSuit = ($"{cardFive[2]}");
            }
            else
            {
                cardFiveValue = ($"{cardFive[0]}");
                string cardFiveSuit = ($"{cardFive[1]}");
            }

            // converts the string values of the cards into integer values
            int numericalCardOneValue = Int32.Parse(cardOneValue);
            int numericalCardTwoValue = Int32.Parse(cardTwoValue);
            int numericalCardThreeValue = Int32.Parse(cardThreeValue);
            int numericalCardFourValue = Int32.Parse(cardFourValue);
            int numericalCardFiveValue = Int32.Parse(cardFiveValue);

            // puts the integer values of the cards into an array
            List<int> numericalCardValues = new List<int> { numericalCardOneValue, numericalCardTwoValue, numericalCardThreeValue, numericalCardFourValue, numericalCardFiveValue };
            

            // orders the list of numbers into ascending order
            orderedNumericalCardValues = numericalCardValues.OrderBy(p => p).ToList();

            return orderedNumericalCardValues;
        }

        public static bool RoyalFlush(string[] hand)
        {
            // creates a new list to hold the information from the array for searching the picture cards
            bool result = false;

            // searches the array to see if all five cards are the same suit
            bool sameSuitHearts = Array.TrueForAll(hand, element => element.EndsWith("h"));
            bool sameSuitClubs = Array.TrueForAll(hand, element => element.EndsWith("c"));
            bool sameSuitDiamonds = Array.TrueForAll(hand, element => element.EndsWith("d"));
            bool sameSuitSpades = Array.TrueForAll(hand, element => element.EndsWith("s"));

            // searches for picture cards           
            string[] searchForQueen = Array.FindAll(hand, ele => ele.StartsWith('Q'));
            string[] searchForKing = Array.FindAll(hand, ele => ele.StartsWith('K'));
            string[] searchForJack = Array.FindAll(hand, ele => ele.StartsWith('J'));
            string[] searchForAce = Array.FindAll(hand, ele => ele.StartsWith('A'));
            string[] searchForTen = Array.FindAll(hand, ele => ele.StartsWith('1'));
           
            // counts the picture cards
            int queenCount = searchForQueen.Count();
            int kingCount = searchForKing.Count();
            int jackCount = searchForJack.Count();
            int aceCount = searchForAce.Count();
            int tenCount = searchForTen.Count();

            // poker combination isn't a royal flush if the suits aren't the same
            if ((sameSuitHearts == false) & (sameSuitClubs == false) & (sameSuitDiamonds == false) & (sameSuitSpades == false))
            {
                result = false;
                return result;
            }
            else
            {
            
                // checks if the five cards in the hand are picture cards and for the value 10            
                if (queenCount == 1 && kingCount == 1 && jackCount == 1 && aceCount == 1 && tenCount == 1)
                {
                    result = true;
                    return result;
                }

                else
                {
                    result = false;
                    return result;
                }
            }
        }


        public static bool StraightFlush(string[] hand)
        {
            bool result = false;
           
            // puts the hand into numerical equivalent ie jack becomes 11
            string[] numericalHand = ProgrammingChallengesAnswers.PictureCardsToNumberEquivalent(hand);

            // searches the array to see if all five cards are the same suit
            bool sameSuitHearts = Array.TrueForAll(hand, element => element.EndsWith("h"));
            bool sameSuitClubs = Array.TrueForAll(hand, element => element.EndsWith("c"));
            bool sameSuitDiamonds = Array.TrueForAll(hand, element => element.EndsWith("d"));
            bool sameSuitSpades = Array.TrueForAll(hand, element => element.EndsWith("s"));

            // checks to see if the cards aren't all of the same suit which means the best poker combination cannot be a straight flush
            if ((sameSuitHearts == false) & (sameSuitClubs == false) & (sameSuitDiamonds == false) & (sameSuitSpades == false))
            {
                result = false;
                return result;
            }
            else
            {
                // checks if the five cards in the hand are consecutive
            
                // puts the card values into a method which ordered them from smallest to largest
                List<int> orderedNumericalCardValues = ProgrammingChallengesAnswers.OrderedCardValues(numericalHand);
                
                int lowestCardValue = orderedNumericalCardValues[0];

                // checks the ordered list of card values to see if they are consecutive
                for (int i = 0; i < orderedNumericalCardValues.Count; i++)
                {
                    if (orderedNumericalCardValues[i] - i != lowestCardValue)
                    {
                        result = false;
                        return result;
                    }
                }

                result = true;
                return result;

            }
        }

        public static bool FourOfAKind(string[] hand)
        {
            bool result = false;
           
            // puts the hand into numerical equivalent ie jack becomes 11
            string[] numericalHand = ProgrammingChallengesAnswers.PictureCardsToNumberEquivalent(hand);

            // puts the card values into a method which orders them from smallest to largest
            List<int> orderedNumericalCardValues = ProgrammingChallengesAnswers.OrderedCardValues(numericalHand);
            
            int counterOne = 0;
            int counterTwo = 0;
            int counterThree = 0;
            int counterFour = 0;
            int counterFive = 0;
            
            // counts the number of cards which have the same value
            for (int i = 0; i <=4; i++)
            {
                if (orderedNumericalCardValues[0] == orderedNumericalCardValues[i])
                {
                    counterOne = counterOne + 1;   
                }

                if (orderedNumericalCardValues[1] == orderedNumericalCardValues[i])
                {
                    counterTwo = counterTwo + 1;
                }

                if (orderedNumericalCardValues[2] == orderedNumericalCardValues[i])
                {
                    counterThree = counterThree + 1;
                }

                if (orderedNumericalCardValues[3] == orderedNumericalCardValues[i])
                {
                    counterFour = counterFour + 1;
                }

                if (orderedNumericalCardValues[4] == orderedNumericalCardValues[i])
                {
                    counterFive = counterFive + 1;
                }
            }

            // checks the counters to see if any are 4 which means four of a kind
            if (counterOne == 4 || counterTwo == 4 || counterThree == 4 || counterFour == 4 || counterFive == 4)
            {
                result = true;
                return result;
            }
            else
            {
                result = false;
                return result;
            }
        }

        public static bool FullHouse(string[] hand)
        {
            bool result = false;          

            // puts the hand into numerical equivalent ie jack becomes 11
            string[] numericalHand = ProgrammingChallengesAnswers.PictureCardsToNumberEquivalent(hand);

            // puts the card values into a method which orders them from smallest to largest
            List<int> orderedNumericalCardValues = ProgrammingChallengesAnswers.OrderedCardValues(numericalHand);
            
            int counterOne = 0;
            int counterTwo = 0;
            int counterThree = 0;
            int counterFour = 0;
            int counterFive = 0;
            
            // counts the number of cards which have the same value
            for (int i = 0; i <= 4; i++)
            {
                if (orderedNumericalCardValues[0] == orderedNumericalCardValues[i])
                {
                    counterOne = counterOne + 1;
                }

                if (orderedNumericalCardValues[1] == orderedNumericalCardValues[i])
                {
                    counterTwo = counterTwo + 1;
                }

                if (orderedNumericalCardValues[2] == orderedNumericalCardValues[i])
                {
                    counterThree = counterThree + 1;
                }

                if (orderedNumericalCardValues[3] == orderedNumericalCardValues[i])
                {
                    counterFour = counterFour + 1;
                }

                if (orderedNumericalCardValues[4] == orderedNumericalCardValues[i])
                {
                    counterFive = counterFive + 1;
                }
            }

            // checks the counters for three cards matching and two cards matching which is a full house
            if ((counterOne == 3 || counterTwo == 3 || counterThree == 3 || counterFour == 3 || counterFive == 3) && (counterOne == 2 || counterTwo == 2 || counterThree == 2 || counterFour == 2 || counterFive == 2))
            {
                result = true;
                return result;
            }
            else
            {
                result = false;
                return result;
            }
        }

        public static bool Flush(string[] hand)
        {
            bool result = false;

            // searches the array to see if all five cards are the same suit
            bool sameSuitHearts = Array.TrueForAll(hand, element => element.EndsWith("h"));
            bool sameSuitClubs = Array.TrueForAll(hand, element => element.EndsWith("c"));
            bool sameSuitDiamonds = Array.TrueForAll(hand, element => element.EndsWith("d"));
            bool sameSuitSpades = Array.TrueForAll(hand, element => element.EndsWith("s"));

            // checks to see if the suits arent the same which means the poker combination isn't a flush
            if ((sameSuitHearts == false) & (sameSuitClubs == false) & (sameSuitDiamonds == false) & (sameSuitSpades == false))
            {
                result = false;
                return result;
            }
            else if ((sameSuitHearts == true) || (sameSuitClubs == true) || (sameSuitDiamonds == true) || (sameSuitSpades == true))
            {
                result = true;
                return result;
            }

            result = false;
            return result;
        }

        public static bool Straight(string[] hand)
        {
            bool result = false;

            // puts the hand into numerical equivalent ie jack becomes 11
            string[] numericalHand = ProgrammingChallengesAnswers.PictureCardsToNumberEquivalent(hand);
                       
            // puts the card values into a method which orders them from smallest to largest
            List<int> orderedNumericalCardValues = ProgrammingChallengesAnswers.OrderedCardValues(numericalHand);

            int lowestCardValue = orderedNumericalCardValues[0];

            // checks the ordered list of card values to see if they are consecutive
            for (int i = 0; i < orderedNumericalCardValues.Count; i++)
            {
                if (orderedNumericalCardValues[i] - i != lowestCardValue)
                {
                    result = false;
                    return result;
                }
            }

            result = true;
            return result;

        }

        public static bool ThreeOfAKind(string[] hand)
        {
            bool result = false;

            // puts the hand into numerical equivalent ie jack becomes 11
            string[] numericalHand = ProgrammingChallengesAnswers.PictureCardsToNumberEquivalent(hand);

            // puts the card values into a method which orders them from smallest to largest
            List<int> orderedNumericalCardValues = ProgrammingChallengesAnswers.OrderedCardValues(numericalHand);
                        
            int counterOne = 0;
            int counterTwo = 0;
            int counterThree = 0;
            int counterFour = 0;
            int counterFive = 0;

            // counts the number of cards which have the same value
            for (int i = 0; i <= 4; i++)
            {
                if (orderedNumericalCardValues[0] == orderedNumericalCardValues[i])
                {
                    counterOne = counterOne + 1;
                }

                if (orderedNumericalCardValues[1] == orderedNumericalCardValues[i])
                {
                    counterTwo = counterTwo + 1;
                }

                if (orderedNumericalCardValues[2] == orderedNumericalCardValues[i])
                {
                    counterThree = counterThree + 1;
                }

                if (orderedNumericalCardValues[3] == orderedNumericalCardValues[i])
                {
                    counterFour = counterFour + 1;
                }

                if (orderedNumericalCardValues[4] == orderedNumericalCardValues[i])
                {
                    counterFive = counterFive + 1;
                }
            }

            // checks the counters for three cards matching 
            if ((counterOne == 3 || counterTwo == 3 || counterThree == 3 || counterFour == 3 || counterFive == 3))
            { 
                result = true;
                return result;
            }
            else
            {
                result = false;
                return result;
            }
        }

        public static bool TwoPair(string[] hand)
        {
            bool result = false;

            // puts the hand into numerical equivalent ie jack becomes 11
            string[] numericalHand = ProgrammingChallengesAnswers.PictureCardsToNumberEquivalent(hand);

            // puts the card values into a method which orders them from smallest to largest
            List<int> orderedNumericalCardValues = ProgrammingChallengesAnswers.OrderedCardValues(numericalHand);

            int counterOne = 0;
            int counterTwo = 0;
            int counterThree = 0;
            int counterFour = 0;
            int counterFive = 0;

            // counts the number of cards which have the same value
            for (int i = 0; i <= 4; i++)
            {
                if (orderedNumericalCardValues[0] == orderedNumericalCardValues[i])
                {
                    counterOne = counterOne + 1;
                }

                if (orderedNumericalCardValues[1] == orderedNumericalCardValues[i])
                {
                    counterTwo = counterTwo + 1;
                }

                if (orderedNumericalCardValues[2] == orderedNumericalCardValues[i])
                {
                    counterThree = counterThree + 1;
                }

                if (orderedNumericalCardValues[3] == orderedNumericalCardValues[i])
                {
                    counterFour = counterFour + 1;
                }

                if (orderedNumericalCardValues[4] == orderedNumericalCardValues[i])
                {
                    counterFive = counterFive + 1;
                }
            }

            // checks the counters for two pairs
            if ((counterOne + counterTwo + counterThree + counterFour + counterFive == 9))
            {
                result = true;
                return result;
            }
            else 
            {
                result = false;
                return result;
            }
        }

        public static bool Pair(string[] hand)
        {
            bool result = false;

            // puts the hand into numerical equivalent ie jack becomes 11
            string[] numericalHand = ProgrammingChallengesAnswers.PictureCardsToNumberEquivalent(hand);

            // puts the card values into a method which orders them from smallest to largest
            List<int> orderedNumericalCardValues = ProgrammingChallengesAnswers.OrderedCardValues(numericalHand);

            int counterOne = 0;
            int counterTwo = 0;
            int counterThree = 0;
            int counterFour = 0;
            int counterFive = 0;

            // counts the number of cards which have the same value
            for (int i = 0; i <= 4; i++)
            {
                if (orderedNumericalCardValues[0] == orderedNumericalCardValues[i])
                {
                    counterOne = counterOne + 1;
                }

                if (orderedNumericalCardValues[1] == orderedNumericalCardValues[i])
                {
                    counterTwo = counterTwo + 1;
                }

                if (orderedNumericalCardValues[2] == orderedNumericalCardValues[i])
                {
                    counterThree = counterThree + 1;
                }

                if (orderedNumericalCardValues[3] == orderedNumericalCardValues[i])
                {
                    counterFour = counterFour + 1;
                }

                if (orderedNumericalCardValues[4] == orderedNumericalCardValues[i])
                {
                    counterFive = counterFive + 1;
                }
            }

            // checks the counters for a pair
            if ((counterOne + counterTwo + counterThree + counterFour + counterFive == 7))
            {
                result = true;
                return result;
            }
            else
            {
                result = false;
                return result;
            }


        }

        public static string PokerHandRanking(string[] hand, out string handValue)
        {
            // initialise variables
            string errorMessage = null;
            handValue = "";
            // 5 rows, 3 columns
            string[,] cardsInHand = new string[5, 3];


            // check length of each card is 2 or 3 characters
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i].Length != 2 && hand[i].Length != 3)
                {
                    errorMessage = $"{hand[i]} card is not a valid length";
                    return errorMessage;
                }
            }

            // create new array object for comparisons
            for (int i = 0; i < hand.Length; i++)
            {
                string suit = hand[i].Last().ToString();
                string faceValue = null;

                if (hand[i].Length == 2)
                {
                    faceValue = hand[i].First().ToString();
                }
                else
                {
                    faceValue = hand[i].Substring(0, 2);
                }

                // validate the cards suit
                if (suit != "h" &&
                    suit != "s" &&
                    suit != "c" &&
                    suit != "d")
                {
                    errorMessage = $"{hand[i]} suit is not in range";
                    return errorMessage;
                }

                // set suit in our new array
                cardsInHand[i, 0] = hand[i].Last().ToString();

                // validates the cards value
                int cardIntValue = -1;
                switch (hand[i].First().ToString())
                {
                    case "A":
                        cardIntValue = 14;
                        break;
                    case "K":
                        cardIntValue = 13;
                        break;
                    case "Q":
                        cardIntValue = 12;
                        break;
                    case "J":
                        cardIntValue = 11;
                        break;
                    default:
                        bool isInt = int.TryParse(faceValue, out cardIntValue);
                        if (!isInt)
                        {
                            errorMessage = $"{hand[i]} value is not a valid number or face";
                            return errorMessage;
                        }
                        else if (cardIntValue < 2 || cardIntValue > 10)
                        {
                            errorMessage = $"{hand[i]} value is not in range";
                            return errorMessage;
                        }
                        break;
                }

                // set card face value e.g. 10, K, Q in our array
                cardsInHand[i, 1] = faceValue;

                // set card int value in our array
                cardsInHand[i, 2] = cardIntValue.ToString();
            }

            // put array in order so we can check for straight
            for (int a = 0; a < hand.Length; a++)
            {
                for (int i = 0; i < hand.Length; i++)
                {
                    int currentCardValue = Convert.ToInt32(cardsInHand[i, 2]);
                    if (i != hand.Length - 1)
                    {
                        int nextCardValue = Convert.ToInt32(cardsInHand[i + 1, 2]);

                        string tempFaceValue = null;
                        string tempIntValue = null;
                        string tempSuitValue = null;

                        if (currentCardValue > nextCardValue)
                        {
                            tempSuitValue = cardsInHand[i + 1, 0];
                            tempFaceValue = cardsInHand[i + 1, 1];
                            tempIntValue = cardsInHand[i + 1, 2];

                            cardsInHand[i + 1, 0] = cardsInHand[i, 0];
                            cardsInHand[i + 1, 1] = cardsInHand[i, 1];
                            cardsInHand[i + 1, 2] = cardsInHand[i, 2];

                            cardsInHand[i, 0] = tempSuitValue;
                            cardsInHand[i, 1] = tempFaceValue;
                            cardsInHand[i, 2] = tempIntValue;
                        }
                    }
                }
            }

            // check the values of the hand now they are validated

            // initialise check variables
            string twoOfPair1 = null;
            string twoOfPair2 = null;
            string threeOf = null;
            string fourOf = null;
            string flushCheck = null;
            int straightCheck = -1;

            // check for different hand criteria 
            for (int a = 0; a < hand.Length; a++)
            {
                int numberOfKind = 1;
                string currentCardFaceValue = cardsInHand[a, 1];
                string currentCardSuit = cardsInHand[a, 0];

                if (a == 0)
                {
                    // start with assuming you have a flush
                    flushCheck = currentCardSuit;

                    // start with assuming you have a straight
                    straightCheck = Convert.ToInt32(cardsInHand[a, 2]);
                }

                for (int b = 0; b < hand.Length; b++)
                {
                    // dont check the card against itself
                    if (currentCardSuit != cardsInHand[b, 0] || currentCardFaceValue != cardsInHand[b, 1])
                    {
                        // if the card is the same value but is not the same suit (aka not the same card)
                        // increase number of a kind
                        if (currentCardFaceValue == cardsInHand[b, 1])
                        {
                            numberOfKind++;
                        }

                        // if any card is not matching the suit, then no flush
                        if (a == 0 && currentCardSuit != cardsInHand[b, 0])
                        {
                            flushCheck = null;
                        }

                        // if value of next card -1 is the same as current value, continue to check for straight
                        if (a == 0)
                        {
                            if (straightCheck != -1 && straightCheck == Convert.ToInt32(cardsInHand[b, 2]) - 1)
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
                        if (twoOfPair1 == null)
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
            bool royalFlush = (flushCheck != null && straightCheck == 14);
            bool straightFlush = (flushCheck != null && straightCheck != -1);
            bool fourOfAKind = (fourOf != null);
            bool fullHouse = (threeOf != null && twoOfPair1 != null);
            bool flush = (flushCheck != null);
            bool straight = (straightCheck != -1);
            bool threeOfAKind = (threeOf != null);
            bool twoPairs = (twoOfPair1 != null && twoOfPair2 != null);
            bool pair = (twoOfPair1 != null);

            if (royalFlush) { handValue = "Royal Flush"; }
            else if (straightFlush) { handValue = "Straight Flush"; }
            else if (fourOfAKind) { handValue = "Four of A Kind"; }
            else if (fullHouse) { handValue = "Full House"; }
            else if (flush) { handValue = "Flush"; }
            else if (straight) { handValue = "Straight"; }
            else if (threeOfAKind) { handValue = "Three Of A Kind"; }
            else if (twoPairs) { handValue = "Two Pairs"; }
            else if (pair) { handValue = "Pair"; }
            else { handValue = "High Card"; }

            return errorMessage;
        }
    }
}       
       





