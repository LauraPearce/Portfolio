using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public static class BattleshipsLibrary
    {

        public static string[,] CreateGrid()
        {
            // creates a 10x10 array as the grid
            string[,] Grid = new string[10, 10];

            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    Grid[j, i] = ".";
                }
            }            
            return Grid;
        }

        public static bool ValidateCoordinate(string userCoordinate)
        {
            bool result = false;
            
            // checks if the coordinate entered begins with a valid letter
            switch (userCoordinate[0])
            {
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'G':
                case 'H':
                case 'I':
                case 'J':

                    // if the coordinate begins with a valid letter, checks for a correct column number
                    if (userCoordinate.Length == 2)
                    {
                        if (char.IsDigit(userCoordinate[1]) && userCoordinate[1] != '0')
                        {
                            result = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (userCoordinate.Length == 3)
                     
                    {
                        // checks the coordinate is valid if it contains a 10
                        if (userCoordinate[1] == '1' && userCoordinate[2] == '0')
                        {
                            result = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }

                default:
                    result = false;
                    break;
            }

            return result;
        }

        public static int ConvertCoordinateIntoArrayIndex(string userCoordinate, out int rowCoordinate)
        {
            // separates the user inputted column and row 
            string userRow = userCoordinate.Substring(0, 1);

            // converts the coordinate letter into a number that will be the array index
            switch (userRow[0])
            {
                case 'A':
                    userRow = userRow.Replace('A', '9');
                    break;
                case 'B':
                    userRow = userRow.Replace('B', '8');
                    break;
                case 'C':
                    userRow = userRow.Replace('C', '7');
                    break;
                case 'D':
                    userRow = userRow.Replace('D', '6');
                    break;
                case 'E':
                    userRow = userRow.Replace('E', '5');
                    break;
                case 'F':
                    userRow = userRow.Replace('F', '4');
                    break;
                case 'G':
                    userRow = userRow.Replace('G', '3');
                    break;
                case 'H':
                    userRow = userRow.Replace('H', '2');
                    break;
                case 'I':
                    userRow = userRow.Replace('I', '1');
                    break;
                case 'J':
                    userRow = userRow.Replace('J', '0');
                    break;

                default:
                    break;
            }

            // separated the column number from the user inputted coordinate 
            string userColumn = userCoordinate.Substring(1);
            
            // converts the coordinate columm number into a zero-based index number for the array
            if (userCoordinate.Length == 2)
            {              
                for (int i = 1; i <= 10; i++)
                {
                    string index = i.ToString();
                    
                    if (userColumn == index)
                    { 
                        int arrayRowNumber = i - 1;
                        string arrayRowNumberAsString = arrayRowNumber.ToString();
                        userColumn = userColumn.Replace(index, arrayRowNumberAsString);
                        break;
                    }
                }
            }
            else if (userCoordinate.Length == 3)
            {
                userColumn = userColumn.Replace("10", "9");
            }
            
            // numerical coordinate converted from string to integer and into an array index
            int columnCoordinate = Convert.ToInt32(userColumn);
            rowCoordinate = Convert.ToInt32(userRow);

            return columnCoordinate;
        }
            
        public static string ConvertArrayIndexIntoCoordinate(int rowNumber, int columnNumber)
        {
            // initialise variables
            string computerRow = null;
            string userColumn = null;
            string computerCoordinate = null;
            string arrayColumnNumberAsString = null;

            // converts the array index for row into a coordinate letter
            switch (rowNumber)
            {
                case 0:
                    computerRow = "J";
                    break;
                case 1:
                    computerRow = "I";
                    break;
                case 2:
                    computerRow = "H";
                    break;
                case 3:
                    computerRow = "G";
                    break;
                case 4:
                    computerRow = "F";
                    break;
                case 5:
                    computerRow = "E";
                    break;
                case 6:
                    computerRow = "D";
                    break;
                case 7:
                    computerRow = "C";
                    break;
                case 8:
                    computerRow = "B";
                    break;
                case 9:
                    computerRow = "A";
                    break;
                default:
                    break;
            }

            // converts array index for column into a string coordinate
            for (int i = 1; i <= 10; i++)
            {               
                if (i ==  columnNumber)
                {
                    int arrayColumnNumber = i + 1;
                    arrayColumnNumberAsString = arrayColumnNumber.ToString();
                    break;
                }
            }

            computerCoordinate = $"{computerRow}{arrayColumnNumberAsString}";

            return computerCoordinate;
        }


        public static bool CheckCoordinateDuplication(string[,] grid, int columnCoordinate, int rowCoordinate, out string message)
        {
            bool duplicate = false;
            message = null;

            if (grid[rowCoordinate, columnCoordinate] != ".")
            {
                duplicate = true;
                message = "You have already entered this coordinate. Please try again.";
            }
            
            return duplicate;     
        }

        public static string[,] UserBoatPlacement(int rowCoordinate, int columnCoordinate, string[,] playerOceanGrid, string initialOfBoat, string userBoatDirection, int lengthOfBoat, out string duplicateResult)
        {
            // intialising variables
            duplicateResult = null;
            int columnCounter = columnCoordinate;
            int rowCounter = rowCoordinate;

            // if direction is horizontal, checks if the boat will overlap another
            
                for (int j = 1; j <= lengthOfBoat; j++)
                {
                    bool invalidCoordinate = BattleshipsLibrary.CheckCoordinateDuplication(playerOceanGrid, columnCoordinate, rowCoordinate, out string message);

                    if ((columnCounter > 9) || (columnCounter < 0) || (rowCounter > 9) || (rowCounter < 0)) 
                    {
                        invalidCoordinate = true;
                    }

                    if (invalidCoordinate == true)
                    {
                        duplicateResult = "This boat will overlap another or go over the edge of the grid.";
                        return playerOceanGrid;
                    }

                    if (userBoatDirection == "h")
                    {
                        columnCounter += 1;
                    }
                    else if (userBoatDirection == "v")
                    {
                        rowCounter += 1;
                    }
                }

                // if there are no boats already placed in the array in those elements, the boat name will be added
                for (int d = 1; d <= lengthOfBoat; d++)
                {
                    if (userBoatDirection == "h") 
                    {
                        playerOceanGrid[rowCoordinate, columnCoordinate] = initialOfBoat;
                        columnCoordinate += 1;
                        duplicateResult = "Not a duplicate";
                    }

                    if (userBoatDirection == "v")
                    {
                        playerOceanGrid[rowCoordinate, columnCoordinate] = initialOfBoat;
                        rowCoordinate += 1;
                        duplicateResult = "Not a duplicate";
                    }
                }

            return playerOceanGrid;
        }

        public static string[,] ComputerBoatPlacement()
        {
            // initialising variables
            string nameOfBoat = null;

            string[,] computerOceanGrid = BattleshipsLibrary.CreateGrid();

            int lengthOfBoat = 0;
            int rowNumber = 0;
            int columnNumber = 0;

            Random random = new Random();
                            
            // for loop and switch to change boat name and length for each placement
            for (int i = 1; i <= 5; i++)
            {
                switch (i)
                {

                    // each case names the boat, assigns the length and generates random row and column numbers within
                    // the limits of the grid so there are no overhanging boats
                    case 1:
                        nameOfBoat = "C";
                        lengthOfBoat = 5;
                        rowNumber = random.Next(0,5);
                        columnNumber = random.Next(0, 5);
                        break;
                    case 2:
                        nameOfBoat = "B";
                        lengthOfBoat = 4;
                        rowNumber = random.Next(0, 6);
                        columnNumber = random.Next(0, 6);
                        break;
                    case 3:
                        nameOfBoat = "R";
                        lengthOfBoat = 3; 
                        rowNumber = random.Next(0, 7);
                        columnNumber = random.Next(0, 7);
                        break;
                    case 4:
                        nameOfBoat = "S";
                        lengthOfBoat = 3;
                        rowNumber = random.Next(0, 7);
                        columnNumber = random.Next(0, 7);
                        break;
                    case 5:
                        nameOfBoat = "D";
                        lengthOfBoat = 2;
                        rowNumber = random.Next(0, 8);
                        columnNumber = random.Next(0, 8);
                        break;
                    default:
                        break;
                }
                                
                    // decide direction of boat using random number generator, 1 for horizontal and 2 for vertical
                    int direction = random.Next(1, 3);
                    int columnCounter = columnNumber;
                    int rowCounter = rowNumber;
                    
                    // calculates the computer boat placement if the random direction chosen is horizontal
                    if (direction == 1)
                    {
                        for (int j = 1; j <= lengthOfBoat; j++)
                        {                           

                            //checks if there are any other boats already in the array elements needed for the new boat
                            if (computerOceanGrid[rowNumber, columnCounter] != ".")
                            {
                                computerOceanGrid = ComputerBoatPlacement();
                                return computerOceanGrid;
                            }
                            
                            columnCounter += 1;
                        }

                        // if there are no boats already placed in the array in those elements, the boat name will be added
                        
                        for (int d = 1; d <= lengthOfBoat; d++)
                        {
                            computerOceanGrid[rowNumber, columnNumber] = nameOfBoat;
                            columnNumber += 1;
                        }
                    }

                    // calculates the computer boat placement if the random direction chosen is vertical
                    else if (direction == 2)
                    {
                        for (int j = 1; j <= lengthOfBoat; j++)
                        {                            
                            //checks if there are any other boats already in the array elements needed for the new boat
                            if (computerOceanGrid[rowCounter, columnNumber] != ".")
                            {
                                computerOceanGrid = ComputerBoatPlacement();
                                return computerOceanGrid;
                        }

                            rowCounter += 1;
                        }

                        // if there are no boats already placed in the array in those elements, the boat name will be added
                        
                        for (int d = 1; d <= lengthOfBoat; d++)
                        {                            
                            computerOceanGrid[rowNumber, columnNumber] = nameOfBoat;
                            rowNumber += 1;
                        }
                    }                           
            }

            return computerOceanGrid;        
        }

        public static string WhatIsTheBoatName(string hitResult)
        {
            string boatName = "Boat name not found";

            switch (hitResult)
            {
                case "C":
                    boatName = "Carrier";
                    break;
                case "B":
                    boatName = "Battleship";
                    break;
                case "R":
                    boatName = "Cruiser";
                    break;
                case "S":
                    boatName = "Submarine";
                    break;
                case "D":
                    boatName = "Destroyer";
                    break;
                default:
                    break;
            }

            return boatName;
        }

        public static bool HasABoatBeenSunk(string hitResult,
            int carrierHitCounter,
            int battleshipHitCounter,
            int cruiserHitCounter,
            int submarineHitCounter,
            int destroyerHitCounter,
            out int updatedCarrierHitCounter,
            out int updatedBattleshipHitCounter,
            out int updatedCruiserHitCounter,
            out int updatedSubmarineHitCounter,
            out int updatedDestroyerHitCounter,
            out string message)
        {
            // intialising variables
            message = null;
            bool result = true;
            updatedBattleshipHitCounter = battleshipHitCounter;
            updatedCruiserHitCounter = cruiserHitCounter;
            updatedCarrierHitCounter = carrierHitCounter;
            updatedSubmarineHitCounter = submarineHitCounter;
            updatedDestroyerHitCounter = destroyerHitCounter;

            switch (hitResult)
            {
                case "Carrier has been hit!":
                    updatedCarrierHitCounter = carrierHitCounter + 1;

                    if (updatedCarrierHitCounter == 5)
                    {
                        message = "The Carrier has been sunk!";
                        break;
                    }

                    break;

                case "Battleship has been hit!":
                    updatedBattleshipHitCounter = battleshipHitCounter + 1;

                    if (updatedBattleshipHitCounter == 4)
                    {
                        message = "The Battleship has been sunk!";
                        break;
                    }

                    break;

                case "Cruiser has been hit!":
                    updatedCruiserHitCounter = cruiserHitCounter + 1;

                    if (updatedCruiserHitCounter == 3)
                    {
                        message = "The Cruiser has been sunk!";
                        break;
                    }
                    break;

                case "Submarine has been hit!":
                    updatedSubmarineHitCounter = submarineHitCounter + 1;

                    if (updatedSubmarineHitCounter == 3)
                    {
                        message = "The Submarine has been sunk!";
                        break;
                    }
                    break;

                case "Destroyer has been hit!":
                    updatedDestroyerHitCounter = destroyerHitCounter + 1;

                    if (updatedDestroyerHitCounter == 2)
                    {
                        message = "The Destroyer has been sunk!";
                        break;
                    }
                    break;
                default:
                    result = false;
                    break;
            }
                   
            return result;
        }

        public static string[,] UserFire(string userCoordinate, string[,] playerTargetBoard, string[,] computerOceanGrid, int userWinCount, out string hitResult, out int updatedUserWinCount)
        {  
            // user inputted coordinate converted into numerical form
            int columnCoordinate = ConvertCoordinateIntoArrayIndex(userCoordinate, out int rowCoordinate);

            // check user fire against computer ocean grid and users shot recorded on the player target board
            if (computerOceanGrid[rowCoordinate, columnCoordinate] == ".")
            {
                hitResult = "Miss!";
                playerTargetBoard[rowCoordinate, columnCoordinate] = "O";
                updatedUserWinCount = userWinCount;
            }
            else
            {
                hitResult = computerOceanGrid[rowCoordinate, columnCoordinate];
                string boatName = WhatIsTheBoatName(hitResult);
                hitResult = $"{boatName} has been hit!";
                playerTargetBoard[rowCoordinate, columnCoordinate] = "X";
                updatedUserWinCount = userWinCount + 1;
            }

            return playerTargetBoard;
        }


        public static string[,] ComputerFire(string[,] computerTargetBoard, string[,] playerOceanGrid, int computerWinCount, out string computerHitResult, out int updatedComputerWinCount, out string computerCoordinate)
        {
            // generates a random coordinate
            Random random = new Random();
            int columnCoordinate = random.Next(0, 9);
            int rowCoordinate = random.Next(0, 9);

            
            //checks if the computer random coordinate is a duplicate
            bool isComputerCoordinateADuplicate = CheckCoordinateDuplication(computerTargetBoard,
                columnCoordinate,
                rowCoordinate,
                out string message);

            while (isComputerCoordinateADuplicate == true)
            {
                columnCoordinate = random.Next(0, 9);
                rowCoordinate = random.Next(0, 9);

                isComputerCoordinateADuplicate = CheckCoordinateDuplication(computerTargetBoard,
                columnCoordinate,
                rowCoordinate,
                out message);
            }
            
            // check computer fire against user ocean grid and record shot on computer target grid
            if (playerOceanGrid[rowCoordinate, columnCoordinate] == ".")
            {
                computerHitResult = "Miss!";
                computerTargetBoard[rowCoordinate, columnCoordinate] = "O";
                updatedComputerWinCount = computerWinCount;
            }
            else
            {
                computerHitResult = playerOceanGrid[rowCoordinate, columnCoordinate];
                string boatName = WhatIsTheBoatName(computerHitResult);
                computerHitResult = $"{boatName} has been hit!";
                computerTargetBoard[rowCoordinate, columnCoordinate] = "X";
                updatedComputerWinCount = computerWinCount + 1;
            }

            computerCoordinate = ConvertArrayIndexIntoCoordinate(rowCoordinate, columnCoordinate);

            return computerTargetBoard;
        }
    }
}
