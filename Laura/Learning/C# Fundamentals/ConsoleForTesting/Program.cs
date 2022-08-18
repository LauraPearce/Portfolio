using ConsoleForTesting;

bool isValidChoice = false;
while (isValidChoice == false)
{
    Console.WriteLine("Please select the code you would like to run:");
    Console.WriteLine(" 1. Programming Challenges");
    Console.WriteLine(" 2. Battleships");
    Console.WriteLine(" 3. OOP Animals Example");
    Console.WriteLine(" 4. OOP School Example");
    Console.WriteLine(" 5. OOP Poker Example");
    Console.WriteLine();

    string input = Console.ReadLine();
    Console.WriteLine();

    Console.Clear();
    switch (input)
    {
        case "1":
            ProgrammingChallengesConsole.Run();
            isValidChoice = true;
            break;
        case "2":
            BattleshipsConsole.Run();
            isValidChoice = true;
            break;
        case "3":
            Console.WriteLine("This is the result of creating and manipulating a number of OOP Animal objects");
            Console.WriteLine("To understand what is happening here please look at the OOPAnimalConsole.cs file");
            Console.WriteLine("This corresponds to the OOPChallenges project Animal example");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            OOPAnimalConsole.Run();
            isValidChoice = true;
            break;
        case "4":
            Console.WriteLine("This is the result of creating and manipulating a number of OOP School objects");
            Console.WriteLine("To understand what is happening here please look at the OOPSchoolConsole.cs file");
            Console.WriteLine("This corresponds to the OOPChallenges project School example");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            OOPSchoolConsole.Run();
            isValidChoice = true;
            break;
        case "5":
            Console.WriteLine("This is the result of creating and manipulating a number of OOP Poker objects");
            Console.WriteLine("To understand what is happening here please look at the OOPPokerConsole.cs file");
            Console.WriteLine("This corresponds to the Poker project");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            OOPPokerConsole.Run();
            isValidChoice = true;
            break;
        default:
            Console.WriteLine("Please enter a valid menu item");
            Console.WriteLine();
            isValidChoice = false;
            break;
    }
}
