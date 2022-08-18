using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingChallenges;

namespace ConsoleForTesting
{
    public static class ProgrammingChallengesConsole
    {
        public static void Run()
        {
            string GetTextInputFromUser(string message)
            {
                Console.WriteLine(message);
                string userInput = Console.ReadLine();
                Console.WriteLine();
                return userInput;
            }

            int GetNumericInputFromUserNoRange(string message)
            {
                string textInput = GetTextInputFromUser(message);
                bool success = int.TryParse(textInput, out int number);
                return number;
            }

            int GetNumericInputFromUser(string message)
            {
                string textInput = GetTextInputFromUser(message);

                bool success = int.TryParse(textInput, out int number);
                if (success)
                {
                    if (number < 0 || number > 20)
                    {
                        Console.WriteLine("Sorry, your number is too large or too small. Please try again.");
                        return GetNumericInputFromUser(message);
                    }
                    else
                    {
                        return number;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, this is not a valid input.");
                    return GetNumericInputFromUser(message);
                }
            }

            double GetDoubleInputFromUser(string message)
            {
                string textInput = GetTextInputFromUser(message);
                bool success = double.TryParse(textInput, out double number);
                return number;
            }

            double GetNumericInputFromUserLargeRange(string message)
            {
                string textInput = GetTextInputFromUser(message);

                bool success = double.TryParse(textInput, out double convertedNumber);
                if (success)
                {
                    if (convertedNumber < 0 || convertedNumber > 10000)
                    {
                        Console.WriteLine("Sorry, your number is too large or too small. Please try again.");
                        return GetNumericInputFromUserLargeRange(message);
                    }
                    else
                    {
                        return convertedNumber;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, this is not a valid input.");
                    return GetNumericInputFromUserLargeRange(message);
                }
            }

            double ConvertStringToDouble(string number)
            {
                bool success = double.TryParse(number, out double convertedNumber);
                if (success)
                {
                    return convertedNumber;
                }
                else
                {
                    double failedAttempt = 0;
                    Console.WriteLine("Sorry, please try again.");
                    return failedAttempt;
                }
            }

            string GetCardInputFromUser(string message)
            {
                Console.WriteLine(message);
                Console.WriteLine();

                string card = "";

                bool isValueValid = false;
                while (isValueValid == false)
                {
                    Console.WriteLine("Please choose a card value");
                    Console.WriteLine(" 1. Ace");
                    Console.WriteLine(" 2. Two");
                    Console.WriteLine(" 3. Three");
                    Console.WriteLine(" 4. Four");
                    Console.WriteLine(" 5. Five");
                    Console.WriteLine(" 6. Six");
                    Console.WriteLine(" 7. Seven");
                    Console.WriteLine(" 8. Eight");
                    Console.WriteLine(" 9. Nine");
                    Console.WriteLine(" 10. Ten");
                    Console.WriteLine(" 11. Jack");
                    Console.WriteLine(" 12. Queen");
                    Console.WriteLine(" 13. King");
                    string value = Console.ReadLine();
                    Console.WriteLine();

                    switch (value)
                    {
                        case "1":
                            card += "A";
                            isValueValid = true;
                            break;
                        case "2":
                            card += "2";
                            isValueValid = true;
                            break;
                        case "3":
                            card += "3";
                            isValueValid = true;
                            break;
                        case "4":
                            card += "4";
                            isValueValid = true;
                            break;
                        case "5":
                            card += "5";
                            isValueValid = true;
                            break;
                        case "6":
                            card += "6";
                            isValueValid = true;
                            break;
                        case "7":
                            card += "7";
                            isValueValid = true;
                            break;
                        case "8":
                            card += "8";
                            isValueValid = true;
                            break;
                        case "9":
                            card += "9";
                            isValueValid = true;
                            break;
                        case "10":
                            card += "10";
                            isValueValid = true;
                            break;
                        case "11":
                            card += "J";
                            isValueValid = true;
                            break;
                        case "12":
                            card += "Q";
                            isValueValid = true;
                            break;
                        case "13":
                            card += "K";
                            isValueValid = true;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid suit");
                            Console.WriteLine();
                            isValueValid = false;
                            break;
                    }
                }

                Console.WriteLine();

                bool isSuitValid = false;
                while (isSuitValid == false)
                {
                    Console.WriteLine("Please choose a card suit");
                    Console.WriteLine(" 1. Hearts");
                    Console.WriteLine(" 2. Diamonds");
                    Console.WriteLine(" 3. Spades");
                    Console.WriteLine(" 4. Clubs");
                    string suit = Console.ReadLine();
                    Console.WriteLine();

                    switch (suit)
                    {
                        case "1":
                            card += "h";
                            isSuitValid = true;
                            break;
                        case "2":
                            card += "d";
                            isSuitValid = true;
                            break;
                        case "3":
                            card += "s";
                            isSuitValid = true;
                            break;
                        case "4":
                            card += "c";
                            isSuitValid = true;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid suit");
                            Console.WriteLine();
                            isSuitValid = false;
                            break;
                    }
                }

                Console.WriteLine($"You chose {card}");
                Console.WriteLine();
                return card;
            }

                

            string message = null;

            // test 1 - find the smallest and biggest numbers
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("1. Find smallest and biggest numbers in a list of number");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            // collects five numbers from a user and stores in a list
            List<int> userNumbers = new List<int>();
            message = "Please enter an integer between 0-20.";

            for (int i = 0; i < 5; i++)
            {
                int userInput = GetNumericInputFromUser(message);
                userNumbers.Add(userInput);
            }
            
            // displays the biggest and the smallest numbers from the users list       
            List<int> biggestAndSmallestNumbers = ProgrammingChallengesAnswers.FindTheSmallestAndBiggestNumbers(userNumbers);
            Console.WriteLine($"The smallest number is {biggestAndSmallestNumbers[0]} and the biggest number is {biggestAndSmallestNumbers[1]}.");
            Console.WriteLine();



            // test 2 - hacker speak
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("2. Hacker speak (replace certain letters with numbers and symbols)");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            // method to collect user inputted text
            message = "Please enter text you would like converted into Hacker Speak.";
            string userMessage = GetTextInputFromUser(message);

            // trim white space from before and after the user text input
            userMessage = userMessage.Trim();

            // method to convert any a, e, i, o and s characters to 4, 3, 1, 0 and 5 in the user inputted message respectively
            string hackerSpeakMessage = ProgrammingChallengesAnswers.HackerSpeak(userMessage);
            Console.WriteLine($"Your message has been converted from '{userMessage}' to '{hackerSpeakMessage}'.");
            Console.WriteLine();



            // test 3 - how many ds are there
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("3. How many Ds in a piece of text");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            // collect user inputted text
            message = "Please enter text and I will count how many upper or lower case D's there are.";
            userMessage = GetTextInputFromUser(message);

            // search the user inputted text for upper or lower case ds
            int howManyDs = ProgrammingChallengesAnswers.HowManyDs(userMessage);
            Console.WriteLine($"The number of upper and lower case D's in your message is {howManyDs}.");
            Console.WriteLine();



            // test 4 - fizzbuzz interview question
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("4. FizzBuzz (is the number multiple of 3 & 5)");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            // collect and convert user inputted string into an integer 
            message = "Please enter an integer between 1-20.";
            int userNumber = GetNumericInputFromUser(message);

            // check if the user inputted number is a multiple of 3, 5, both or neither
            string fizzBuzzResult = ProgrammingChallengesAnswers.FizzBuzzInterviewQuestion(userNumber);
            Console.WriteLine(fizzBuzzResult);
            Console.WriteLine();



            // test 5 - get the file name
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("5. Working with files");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("-- commented out for portfolio as it used a hardcoded path --");
            Console.WriteLine();

            //TODO: make this use a relative file path

            //// get chosen file name from user
            //message = "Please enter your chosen file name. There must be no spaces or slashes.";
            //string chosenUserFileName = GetTextInputFromUser(message);

            //// create file using user inputted name
            //string path = $"C:\\Users\\carl\\Documents\\Coding Files\\{chosenUserFileName}.txt";
            //StreamWriter completeFile = ProgrammingChallengesAnswers.CreateFile(path);

            //// display file name and full path
            //string displayFullPath = Path.GetFullPath(path);
            //string displayFileName = Path.GetFileName(path);
            //Console.WriteLine($"The full path of your file is {displayFullPath} and the file name with extension is {displayFileName}.");
            //Console.WriteLine();



            // test 6 - among us imposter formula
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("6. Among us imposter formula (what percentage of payers are imposters)");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            double numberOfPlayers = GetDoubleInputFromUser("Please enter the number of players");

            double numberOfImposters = numberOfPlayers + 1;
            while (numberOfImposters > numberOfPlayers)
            {
                numberOfImposters = GetDoubleInputFromUser("Please enter number of imposters");
                if (numberOfImposters > numberOfPlayers)
                {
                    Console.WriteLine("Imposters must be less than the number of players");
                }
            }

            // calculate the chance of being the imposter
            double imposterChance = ProgrammingChallengesAnswers.AmongUsImposterFormula(numberOfPlayers, numberOfImposters);
            Console.WriteLine($"The chances of being an imposter in this game are {imposterChance}%.");



            // test 7 - calculate the mean
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("7. Calculate the average (mean)");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            // creates an array and assigns the message
            string[] userInputArray = new string[5];
            message = "Please enter an integer between 0 - 10000.";

            // puts the user inputs into the array
            for (int i = 0; i < 5; i++)
            {
                string userInput = GetTextInputFromUser(message);
                userInputArray[i] = userInput;
            }

            // calculating the total value of array inputs
            double totalValue = 0;
            double mean = 0;
            foreach (string i in userInputArray)
            {
                double convertedNumber = ConvertStringToDouble(i);
                totalValue = totalValue + convertedNumber;
            }

            // calculating the mean value
            mean = totalValue / userInputArray.Length;
            mean = Math.Round(mean, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine($"The mean value of the array values you entered is {mean}.");
            Console.WriteLine();



            // test 8 - atm pin code validation
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("8. ATM PIN Validation");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            // collect user inputted pin 
            message = "Please enter either a 4 or 6 digit PIN. PIN's must be numerical and include no letters, spaces or special characters.";
            string userPin = GetTextInputFromUser(message);

            // validate the pin entered
            string valid = ProgrammingChallengesAnswers.AtmPinCodeLengthValidation(userPin);
            Console.WriteLine(valid);
            Console.WriteLine();

            // let user continue to try until a correct PIN format is entered
            while (valid != "Thank-you for entering a correct PIN.")
            {
                userPin = GetTextInputFromUser(message);
                valid = ProgrammingChallengesAnswers.AtmPinCodeLengthValidation(userPin);
            }



            // test 9 - is the phone number formatted correctly
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("9. Phone number validation");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            // collect user inputted phone number
            message = "Please enter a phone number in the format '(___) ___-____'.";
            string userPhoneNumber = GetTextInputFromUser(message);

            // check the phone number contains no letters and if it does, allow user to try again
            bool doesItContainLetters = ProgrammingChallengesAnswers.StringCharCheck(userPhoneNumber);
            while (doesItContainLetters == false)
            {
                Console.WriteLine("Your phone number contained letters. Please try again.");
                Console.WriteLine();

                // repeat user through program until input doesn't contain letters
                userPhoneNumber = GetTextInputFromUser(message);
                doesItContainLetters = ProgrammingChallengesAnswers.StringCharCheck(userPhoneNumber);
            }

            // check the phone number length is correct, allow user to try again if not
            string isItLongEnough = ProgrammingChallengesAnswers.StringLengthCheck(userPhoneNumber);
            while (isItLongEnough == "The phone number entered is the wrong length. Please try again.")
            {
                Console.WriteLine("The phone number entered is the wrong length. Please try again.");
                Console.WriteLine();

                // repeat user through program until input doesn't contain letters
                userPhoneNumber = GetTextInputFromUser(message);
                isItLongEnough = ProgrammingChallengesAnswers.StringLengthCheck(userPhoneNumber);
            }

            // check phone number formatting
            string isPhoneNumberFormatCorrect = ProgrammingChallengesAnswers.IsThePhoneNumberFormattedCorrectly(userPhoneNumber);
            while (isPhoneNumberFormatCorrect != "Thank-you, the phone number has been entered correctly.")
            {
                Console.WriteLine("Your phone number was not formatted correctly. Please try again.");
                Console.WriteLine();

                // repeat user through program until input matches formatting example
                userPhoneNumber = GetTextInputFromUser(message);
                doesItContainLetters = ProgrammingChallengesAnswers.StringCharCheck(userPhoneNumber);
                isPhoneNumberFormatCorrect = ProgrammingChallengesAnswers.IsThePhoneNumberFormattedCorrectly(userPhoneNumber);
            }

            Console.WriteLine(isPhoneNumberFormatCorrect);



            // test 10 - check if a number is prime
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("10. Check if a number is prime");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            // collect user inputted number and convert string to integer
            message = "Please enter an integer.";
            int userInputtedNumber = GetNumericInputFromUserNoRange(message);

            //calculate if the number is prime 
            string result = ProgrammingChallengesAnswers.CheckIfANumberIsPrime(userInputtedNumber);
            Console.WriteLine(result);

            // repeat user through program if number doesn't calculate properly
            while (result == "Please try again.")
            {
                Console.WriteLine("Your number was unable to be calculated this time, please try again.");
                Console.WriteLine();
                userInputtedNumber = GetNumericInputFromUserNoRange(message);
                result = ProgrammingChallengesAnswers.CheckIfANumberIsPrime(userInputtedNumber);
                Console.WriteLine(result);
            }



            // bonus test - poker hand ranking
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("11. Poker hand ranking");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            string[] hand = new string[5];

            // puts the user inputs into the array
            for (int i = 0; i < 5; i++)
            {
                string cardInput = GetCardInputFromUser($"Please select card {i+1}.");
                hand[i] = cardInput;
            }

            string errorMessage = ProgrammingChallengesAnswers.PokerHandRanking(hand, out string handValue);

            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                Console.WriteLine(handValue);
            }
            else
            {
                Console.WriteLine(errorMessage);
            }

            Console.WriteLine();
            Console.WriteLine("Please press any key to continue...");
            Console.ReadLine();

        }
    }
}
