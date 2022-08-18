using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships;


namespace ConsoleForTesting
{
    public static class BattleshipsConsole
    {
        public static void Run()
        {
            void FirstPageForUser(string[,] playerTargetBoard)
            {
                for (int i = 0; i <= 9; i++)
                {
                    switch (i)
                    {
                        case 0:
                            Console.Write("  J|");
                            break;
                        case 1:
                            Console.Write("  I|");
                            break;
                        case 2:
                            Console.Write("  H|");
                            break;
                        case 3:
                            Console.Write("  G|");
                            break;
                        case 4:
                            Console.Write("  F|");
                            break;
                        case 5:
                            Console.Write("  E|");
                            break;
                        case 6:
                            Console.Write("  D|");
                            break;
                        case 7:
                            Console.Write("  C|");
                            break;
                        case 8:
                            Console.Write("  B|");
                            break;
                        case 9:
                            Console.Write("  A|");
                            break;
                        default:
                            break;
                    }

                    for (int b = 0; b <= 9; b++)
                    {
                        Console.Write($" {playerTargetBoard[i, b]} |");
                    }

                    switch (i)
                    {
                        case 1:
                            string gameAim = "The aim of the game is to";
                            Console.Write(gameAim.PadLeft(30));
                            break;
                        case 2:
                            gameAim = "find and sink your opponents";
                            Console.Write(gameAim.PadLeft(32));
                            break;
                        case 3:
                            gameAim = "boats.";
                            Console.Write(gameAim.PadLeft(20));
                            break;
                        case 5:
                            gameAim = "Press enter to play.";
                            Console.Write(gameAim.PadLeft(27));
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine();
                    Console.WriteLine("   |----------------------------------------");
                }

                Console.WriteLine("      1   2   3   4   5   6   7   8   9   10");
                Console.ReadLine();
            }

            void DisplayTargetGridToUser(string[,] playerTargetBoard)
            {
                for (int i = 0; i <= 9; i++)
                {
                    switch (i)
                    {
                        case 0:
                            Console.Write("  J|");
                            break;
                        case 1:
                            Console.Write("  I|");
                            break;
                        case 2:
                            Console.Write("  H|");
                            break;
                        case 3:
                            Console.Write("  G|");
                            break;
                        case 4:
                            Console.Write("  F|");
                            break;
                        case 5:
                            Console.Write("  E|");
                            break;
                        case 6:
                            Console.Write("  D|");
                            break;
                        case 7:
                            Console.Write("  C|");
                            break;
                        case 8:
                            Console.Write("  B|");
                            break;
                        case 9:
                            Console.Write("  A|");
                            break;
                        default:
                            break;
                    }

                    for (int b = 0; b <= 9; b++)
                    {
                        Console.Write($" {playerTargetBoard[i, b]} |");
                    }

                    Console.WriteLine();
                    Console.WriteLine("   |----------------------------------------");
                }

                Console.WriteLine("      1   2   3   4   5   6   7   8   9   10");
            }

            void DisplayOceanGridToUser(string[,] playerOceanGrid)
            {
                for (int i = 0; i <= 9; i++)
                {
                    switch (i)
                    {
                        case 0:
                            Console.Write("  J|");
                            break;
                        case 1:
                            Console.Write("  I|");
                            break;
                        case 2:
                            Console.Write("  H|");
                            break;
                        case 3:
                            Console.Write("  G|");
                            break;
                        case 4:
                            Console.Write("  F|");
                            break;
                        case 5:
                            Console.Write("  E|");
                            break;
                        case 6:
                            Console.Write("  D|");
                            break;
                        case 7:
                            Console.Write("  C|");
                            break;
                        case 8:
                            Console.Write("  B|");
                            break;
                        case 9:
                            Console.Write("  A|");
                            break;
                        default:
                            break;
                    }

                    for (int b = 0; b <= 9; b++)
                    {
                        Console.Write($" {playerOceanGrid[i, b]} |");
                    }
                    Console.WriteLine();
                    Console.WriteLine("   |----------------------------------------");
                }
                Console.WriteLine("      1   2   3   4   5   6   7   8   9   10");
            }

            string GetUserInput(string message, string[,] computerOceanGrid)
            {
                Console.WriteLine(message);
                string userInput = Console.ReadLine();

                // checks for blank input
                while (userInput == "")
                {
                    Console.WriteLine("You haven't entered anything, please try again.");
                    userInput = Console.ReadLine();
                }

                userInput = userInput.ToUpper();

                //TODO: revisit refactoring this
                // adds a cheat option to display computer boats
                while (userInput == "CHEAT")
                {
                    Console.Clear();
                    Console.WriteLine("------... YOU SNEAKY SNEAK... BELOW ARE THE COMPUTER'S BOATS... -------");
                    DisplayOceanGridToUser(computerOceanGrid);
                    Console.WriteLine(message);
                    userInput = Console.ReadLine();
                    userInput = userInput.ToUpper();
                }

                return userInput;
            }

            string GetBoatDirection(string[,] computerOceanGrid)
            {
                // asks user for boat direction 
                string message =
                    "Would you like your boat to be placed horizontally or vertically in the grid?" +
                    "\nHorizontal boats start with the left hand side coordinate and vertical boats with the top coordinate." +
                    "\nPlease reply with a H or V";
                string userBoatDirection = GetUserInput(message, computerOceanGrid).ToLower();

                // validates user response about direction of boat placement
                while (userBoatDirection != "h" && userBoatDirection != "v")
                {
                    message = "You have entered an incorrect direction. Please enter 'H' for horizontal or 'V' for vertical.";
                    userBoatDirection = GetUserInput(message, computerOceanGrid).ToLower();
                }
                return userBoatDirection;
            }


            // PROGRAM

            // intialising variables
            string message = null;
            string userCoordinate = null;
            string nameOfBoat = null;
            string duplicateResult = null;
            string userBoatDirection = null;
            string initialOfBoat = null;

            string[,] playerTargetBoard = BattleshipsLibrary.CreateGrid();
            string[,] playerOceanGrid = BattleshipsLibrary.CreateGrid();
            string[,] computerTargetGrid = BattleshipsLibrary.CreateGrid();
            string[,] computerOceanGrid = BattleshipsLibrary.CreateGrid();

            int lengthOfBoat = 0;
            int rowCoordinate = 0;
            int columnCoordinate = 0;

            int userWinCount = 0;
            int computerWinCount = 0;
            int updatedComputerWinCount = 0;
            int updatedUserWinCount = 0;

            int userCarrierHitCounter = 0;
            int userBattleshipHitCounter = 0;
            int userCruiserHitCounter = 0;
            int userSubmarineHitCounter = 0;
            int userDestroyerHitCounter = 0;

            int computerCarrierHitCounter = 0;
            int computerBattleshipHitCounter = 0;
            int computerCruiserHitCounter = 0;
            int computerSubmarineHitCounter = 0;
            int computerDestroyerHitCounter = 0;

            bool isCoordinateValid = false;

            // format and display title and user target grid
            string title = "Let's Play Battleships!";
            int length = title.Length;
            title = title.PadLeft((Console.WindowWidth / 2) + (length / 2));

            Console.Write($"\n {title} \n");
            Console.WriteLine();
            FirstPageForUser(playerTargetBoard);
            Console.Clear();

            // dislay rules for placing boats
            string rulesTitle = ("--------------- Rules for placing ships ---------------");
            string rulesForPlacingShips = (
                "1. Ships must be placed horizontally or vertically, not diagonally. \n\n" +
                "2. Ships must not overlap each other, be placed over the letters or numbers or  go over the edge of the grid.\n\n" +
                "3. You cannot change the position of the ships once the game has begun.");

            int rulesLength = rulesTitle.Length;
            Console.WriteLine();
            Console.WriteLine();
            Console.Write($"{rulesTitle.PadLeft((Console.WindowWidth / 2) + (rulesLength / 2))}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(rulesForPlacingShips);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" ~ ~ ~ ".PadLeft(Console.WindowWidth / 2));
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.Clear();

            // for loop to cycle 5 times to enable the user to place each type of boat 
            for (int i = 1; i <= 5; i++)
            {
                switch (i)
                {
                    case 1:
                        nameOfBoat = "Carrier";
                        initialOfBoat = "C";
                        lengthOfBoat = 5;
                        break;
                    case 2:
                        nameOfBoat = "Battleship";
                        initialOfBoat = "B";
                        lengthOfBoat = 4;
                        break;
                    case 3:
                        nameOfBoat = "Cruiser";
                        initialOfBoat = "R";
                        lengthOfBoat = 3;
                        break;
                    case 4:
                        nameOfBoat = "Submarine";
                        initialOfBoat = "S";
                        lengthOfBoat = 3;
                        break;
                    case 5:
                        nameOfBoat = "Destroyer";
                        initialOfBoat = "D";
                        lengthOfBoat = 2;
                        break;
                    default:
                        break;
                }

                message = $"\nLet's place the {nameOfBoat}, displayed in the grid as '{initialOfBoat}'." +
                    $"\nThe {nameOfBoat} is {lengthOfBoat} coordinates long. " +
                    "\n\nCoordinates must start with the letter first, i.e. A5. " +
                    "\n\nI will ask for your first coordinate and if you would like the boat to lay \n" +
                    "horizontally (side to side) or vertically (up and down)." +
                    $"\n\nPlease enter the first coordinate of the {nameOfBoat} and press Enter.";

                userCoordinate = GetUserInput(message, computerOceanGrid).ToUpper();

                // validate the first coordinate of the boat
                isCoordinateValid = BattleshipsLibrary.ValidateCoordinate(userCoordinate);

                // loop until valid coordinate entered
                while (isCoordinateValid == false)
                {
                    Console.WriteLine();
                    message = $"Incorrect coordinate entered." +
                        $"\n\nPlease enter the first coordinate of the {nameOfBoat} and press Enter." +
                        "\nCoordinates must be between A-J and 1-10.";

                    Console.WriteLine();

                    userCoordinate = GetUserInput(message, computerOceanGrid);
                    isCoordinateValid = BattleshipsLibrary.ValidateCoordinate(userCoordinate);

                    Console.WriteLine();
                    Console.Clear();
                }



                //convert the user coordinate into an array index
                columnCoordinate = BattleshipsLibrary.ConvertCoordinateIntoArrayIndex(userCoordinate, out rowCoordinate);

                // user boat direction and validation
                userBoatDirection = GetBoatDirection(computerOceanGrid);

                // calculates boat coordinates and stores in player ocean grid  
                playerOceanGrid = BattleshipsLibrary.UserBoatPlacement(rowCoordinate, columnCoordinate, playerOceanGrid, initialOfBoat, userBoatDirection, lengthOfBoat, out duplicateResult);

                while (duplicateResult != "Not a duplicate")
                {
                    Console.WriteLine();
                    Console.WriteLine($"{duplicateResult} Press enter to continue.");
                    Console.WriteLine();
                    Console.ReadLine();
                    Console.Clear();
                    DisplayOceanGridToUser(playerOceanGrid);
                    message = $"Enter the first coordinate of the {nameOfBoat}, which will be displayed in the grid as '{initialOfBoat}'." +
                            $"\nThe {nameOfBoat} is {lengthOfBoat} coordinates long.";
                    userCoordinate = GetUserInput(message, computerOceanGrid);
                    Console.WriteLine();
                    isCoordinateValid = BattleshipsLibrary.ValidateCoordinate(userCoordinate);
                    Console.WriteLine();

                    //convert the user coordinate into an array index
                    columnCoordinate = BattleshipsLibrary.ConvertCoordinateIntoArrayIndex(userCoordinate, out rowCoordinate);

                    // ask user to input if they would like their boat to lay horizontally or vertically and validates response
                    userBoatDirection = GetBoatDirection(computerOceanGrid);

                    playerOceanGrid = BattleshipsLibrary.UserBoatPlacement(rowCoordinate, columnCoordinate, playerOceanGrid, initialOfBoat, userBoatDirection, lengthOfBoat, out duplicateResult);
                }

                DisplayOceanGridToUser(playerOceanGrid);
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }

            //random computer generated boat placement for computer ocean grid
            Random random = new Random();
            computerOceanGrid = BattleshipsLibrary.ComputerBoatPlacement();

            Console.Clear();

            // while loop continues the game until one of the players has 17 hits which means all boats have been sunk
            while ((updatedUserWinCount < 17) && (updatedComputerWinCount < 17))
            {
                Console.WriteLine();
                DisplayTargetGridToUser(playerTargetBoard);
                Console.WriteLine();

                // get fire coordinate from user
                message = "Time to fire! Type in a coordinate where you would like to bomb and press enter.";
                userCoordinate = GetUserInput(message, computerOceanGrid);

                // checks the coordinate entered is of the right length, characters etc.
                isCoordinateValid = BattleshipsLibrary.ValidateCoordinate(userCoordinate);

                // if loop cycles until valid coordinate has been entered
                if (isCoordinateValid == true)
                {
                    // convert coordinate into array index
                    columnCoordinate = BattleshipsLibrary.ConvertCoordinateIntoArrayIndex(userCoordinate, out rowCoordinate);

                    //check for duplicate coordinate
                    bool result = BattleshipsLibrary.CheckCoordinateDuplication(playerTargetBoard,
                        columnCoordinate,
                        rowCoordinate,
                        out string hasUserFiredHereBefore);

                    while (result == true)
                    {
                        Console.WriteLine(hasUserFiredHereBefore);
                        Console.WriteLine();

                        userCoordinate = GetUserInput(message, computerOceanGrid);

                        // checks the coordinate entered is of the right length, characters etc.
                        isCoordinateValid = BattleshipsLibrary.ValidateCoordinate(userCoordinate);

                        // if loop cycles until valid coordinate has been entered
                        if (isCoordinateValid == true)
                        {
                            // convert coordinate into array index
                            columnCoordinate = BattleshipsLibrary.ConvertCoordinateIntoArrayIndex(userCoordinate, out rowCoordinate);
                        }

                        result = BattleshipsLibrary.CheckCoordinateDuplication(playerTargetBoard,
                        columnCoordinate,
                        rowCoordinate,
                        out hasUserFiredHereBefore);
                    }

                    // user fire
                    playerTargetBoard = BattleshipsLibrary.UserFire(userCoordinate, playerTargetBoard, computerOceanGrid, userWinCount, out string hitResult, out updatedUserWinCount);

                    // display result of the fire and the player target board to the user 
                    Console.Clear();
                    DisplayTargetGridToUser(playerTargetBoard);
                    Console.WriteLine();
                    Console.WriteLine($"------------------  ~ {hitResult} ~ ------------------");

                    //TODO: add a counter or display how many boats have been sunk and how many are left
                    // displays if any boats have been sunk
                    if (hitResult != "Miss!")
                    {
                        bool hasTheBoatBeenSunk = BattleshipsLibrary.HasABoatBeenSunk(hitResult,
                            userCarrierHitCounter,
                            userBattleshipHitCounter,
                            userCruiserHitCounter,
                            userSubmarineHitCounter,
                            userDestroyerHitCounter,
                            out userCarrierHitCounter,
                            out userBattleshipHitCounter,
                            out userCruiserHitCounter,
                            out userSubmarineHitCounter,
                            out userDestroyerHitCounter,
                            out message);

                        if (hasTheBoatBeenSunk == true)
                        {
                            Console.WriteLine(message);
                        }
                    }

                    userWinCount = updatedUserWinCount;
                }
                else
                {
                    //TODO: verify the user inputted guess for duplicates
                    //TODO: check user input wasn't blank
                    // if a valid coordinate wasnt entered, user input is asked again
                    while (isCoordinateValid == false)
                    {
                        userCoordinate = GetUserInput(message, computerOceanGrid);
                        isCoordinateValid = BattleshipsLibrary.ValidateCoordinate(userCoordinate);
                        //TODO: ensure correct coordinate gets added into the array and displayed to user
                    }
                }

                // computer takes a turn
                //TODO: if computer is a hit, next guess is +1 or -1 horizontally or vertically and a +1 to computerwinner counter
                Console.Write("Now it's the computer's turn to fire! Press enter...");
                Console.ReadLine();
                Console.Clear();

                computerTargetGrid = BattleshipsLibrary.ComputerFire(computerTargetGrid,
                    playerOceanGrid,
                    computerWinCount,
                    out string computerHitResult,
                    out updatedComputerWinCount,
                    out string computerCoordinate);

                //TODO: padright the display of the computer target grid
                DisplayTargetGridToUser(computerTargetGrid);
                Console.WriteLine();
                Console.Write($"Computer fires at {computerCoordinate}... {computerHitResult}!");
                Console.WriteLine();

                //TODO: add a counter or display how many boats have been sunk and how many are left
                // displays if any boats have been sunk
                if (computerHitResult != "Miss!")
                {
                    bool result = BattleshipsLibrary.HasABoatBeenSunk(computerHitResult,
                        computerCarrierHitCounter,
                        computerBattleshipHitCounter,
                        computerCruiserHitCounter,
                        computerSubmarineHitCounter,
                        computerDestroyerHitCounter,
                        out computerCarrierHitCounter,
                        out computerBattleshipHitCounter,
                        out computerCruiserHitCounter,
                        out computerSubmarineHitCounter,
                        out computerDestroyerHitCounter,
                        out message);

                    if (result == true)
                    {
                        Console.WriteLine(message);
                    }
                }

                computerWinCount = updatedComputerWinCount;

                Console.Write("Press enter to continue...".PadLeft(54));
                Console.ReadLine();
                Console.Clear();
            }

            //TODO: break out of while loop if there is a winner
            if (userWinCount == 17)
            {
                Console.WriteLine("Congratulations, you sunk all of the Computer's boats!\nYou Win!");
            }
            else if (computerWinCount == 17)
            {
                Console.WriteLine("The Computer sunk all your boats, good luck next time!");
            }

            Console.WriteLine();
            Console.ReadLine();


        }
    }
}
