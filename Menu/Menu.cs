using DutyAppDB.Services.Contracts;
using DutyAppDB.Shared;

namespace DutyAppDB.Menu;

public class Menu
{
    public static void MainMenu(IDutyService _dutyService, IStudentService _studentService, IDutyAssignmentService _dutyAssignmentService)
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
                        StudentMenu(_studentService);
                        break;
                    case "2":
                        DutyMenu(_dutyService);
                        break;
                    case "3":
                        DutyAssignmentMenu(_dutyAssignmentService);
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

    static void PrintMenu()
    {
        Console.WriteLine("Enter 1 to Student Menu");
        Console.WriteLine("Enter 2 to Duty Menu");
        Console.WriteLine("Enter 3 to Duty Assignment Menu");
        Console.WriteLine("Enter 0 to exit.");
    }

    public static void DutyMenu(IDutyService _dutyService)
    {
        var flag = true;

        while (flag)
        {
            PrintDutyMenu();
            Console.WriteLine("\nPlease enter your option: ");
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
                case "3":
                    _dutyService.GetDuty();
                    Console.WriteLine("");
                    break;
                case "4":
                    _dutyService.UpdateDuty();
                    Console.WriteLine("");
                    break;
                case "5":
                    _dutyService.DeleteDuty();
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
    static void PrintDutyMenu()
    {
        Console.WriteLine("Enter 1 to Create New Duty");
        Console.WriteLine("Enter 2 to View All Duties");
        Console.WriteLine("Enter 3 to View a Duty");
        Console.WriteLine("Enter 4 to Update a Duty");
        Console.WriteLine("Enter 5 to Delete a Duty");
        Console.WriteLine("Enter 0 to go back to main menu.");
    }

    public static void StudentMenu(IStudentService _studentService)
    {
        var flag = true;

        while (flag)
        {
            PrintStudentMenu();
            Console.WriteLine("\nPlease enter your option: ");
            string option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    _studentService.AddStudent();
                    Console.WriteLine("");
                    break;
                case "2":
                    _studentService.GetAllStudent();
                    Console.WriteLine("");
                    break;
                case "3":
                    _studentService.GetStudentById();
                    Console.WriteLine("");
                    break;
                case "4":
                    _studentService.GetStudentByCode();
                    Console.WriteLine("");
                    break;
                case "5":
                    _studentService.UpdateStudent();
                    Console.WriteLine("");
                    break;
                case "6":
                    _studentService.DeleteStudent();
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

       

       

        static void PrintStudentMenu()
        {
            Console.WriteLine("Enter 1 to Add New Student");
            Console.WriteLine("Enter 2 to View All Students");
            Console.WriteLine("Enter 3 to View a Student(Id)");
            Console.WriteLine("Enter 4 to View a Student(Code)");
            Console.WriteLine("Enter 5 to Update a Student");
            Console.WriteLine("Enter 6 to Delete a Student");
            Console.WriteLine("Enter 0 to go back to main menu.");

        }
    }

    public static void DutyAssignmentMenu(IDutyAssignmentService _dutyAssignmentService)
    {
        var flag = true;

        while (flag)
        {
            PrintDutyAssignmentMenu();
            Console.WriteLine("\nPlease enter your option: ");
            string option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    _dutyAssignmentService.CreateDutyAssignment();
                    Console.WriteLine("");
                    break;
                case "2":
                    _dutyAssignmentService.GetAllDutyAssignment();
                    Console.WriteLine("");
                    break;
                case "3":
                    _dutyAssignmentService.GetDutyAssignment();
                    Console.WriteLine("");
                    break;
                case "4":
                    _dutyAssignmentService.UpdateDutyAssignment();
                    Console.WriteLine("");
                    break;
                case "5":
                    _dutyAssignmentService.DeleteDutyAssignment();
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

        static void PrintDutyAssignmentMenu()
        {
            Console.WriteLine("Enter 1 to Assign duty to student");
            Console.WriteLine("Enter 2 to View All duty assignment");
            Console.WriteLine("Enter 3 to View a duty assignment");
            Console.WriteLine("Enter 4 to Update a duty assignment");
            Console.WriteLine("Enter 5 to Delete a duty assiment");
            Console.WriteLine("Enter 0 to go back to main menu.");
        }
    }
}
