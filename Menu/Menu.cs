using DutyAppDB.Services.Contracts;
using DutyAppDB.Shared;

namespace DutyAppDB.Menu;

public class Menu
{
    public static void MainMenu(IDutyService _dutyService)
    {
        bool flag = true;

        try
        {
            while (flag)
            {
                PrintMenu();
                Console.Write("\nPlease enter your preferred option: ");
                string option = Console.ReadLine()!;

                switch (option)
                {
                    case "1":
                        Console.WriteLine("No menu yet");
                        break;
                    case "2":
                        DutyMenu(_dutyService);
                        break;

                    case "0":
                        flag = false;
                        break;
                    default:
                        throw new InvalidOperationException("Unknown operation!");
                }
            }
        }
        catch (InvalidOperationException ioe)
        {
            Helpers.FailureTextOutput(ioe.Message);
        }
        catch (Exception ex)
        {
            Helpers.FailureTextOutput(ex.Message);
        }
    }

    public static void DutyMenu(IDutyService _dutyService)
    {
        var flag = true;

        while (flag)
        {
            PrintDutyMenu();
            Console.Write("\nPlease enter your option: ");
            string option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    _dutyService.CreateDuty();
                    Console.WriteLine("");
                    break;
                case "2":
                    _dutyService.GetAllDuty();
                    Console.WriteLine("");
                    break;
                case "0":
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine("Enter 1 to Student Menu");
        Console.WriteLine("Enter 2 to Duty Menu");
        Console.WriteLine("Enter 3 to Duty Assignment Menu");
        Console.WriteLine("Enter 0 to exit.");
    }

    static void PrintDutyMenu()
    {
        Console.WriteLine("Enter 1 to Create New Duty");
        Console.WriteLine("Enter 2 to View All Duties");
        Console.WriteLine("Enter 3 to View a Duty");
        Console.WriteLine("Enter 4 to Update a Duty");
        Console.WriteLine("Enter 5 to Delete a Duty");
        Console.WriteLine("Enter 0 to go back to main menu.");
    }
}
