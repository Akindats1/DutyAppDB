using ConsoleTables;
using DutyAppDB.Enums;
using DutyAppDB.Models.Dtos.Student;
using DutyAppDB.Models.Entities;
using DutyAppDB.Repositories.Contracts;
using DutyAppDB.Services.Contracts;
using DutyAppDB.Shared;

namespace DutyAppDB.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task AddStudent()
        {
            try
            {
                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine()!;

                Console.Write("Enter Middle Name: ");
                string? middleName = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine()!;
                Console.Write("Enter email: ");
                string email = Console.ReadLine()!;

                int gender = Helpers.SelectEnum("Enter student gender:\nEnter 1 for Male\nEnter 2 for Female: ", 1, 2);
                var Gender = (Gender)gender;

                Console.Write("Enter date of birth (2003-12-25): ");
                var dob = Helpers.TryParseDateTimeOnly(Console.ReadLine()!);
                
                Console.Write("Enter date joined (2003-12-25): ");
                var joinedDate = Helpers.TryParseDateTimeOnly(Console.ReadLine()!);



                var student = new AddStudentDto
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    Email = email,
                    Gender = Gender,
                    DateOfBirth = dob,
                };
                int rowsAffected = await _studentRepository.AddStudent(student);

                if (rowsAffected == 1)
                {
                    Helpers.SuccessTextOutput("Student created successfully!");
                }
                else
                {
                    Helpers.FailureTextOutput("Could not create student!");
                }
            }
            catch (Exception ex)
            {
                Helpers.FailureTextOutput(ex.Message);
            }
        }

        public async Task GetAllStudent()
        {
            try
            {
                var students = await _studentRepository.GetAllStudent();

                if (students.Count > 0)
                {
                    var table = new ConsoleTable("ID", "StudentCode", "FirstName", "MiddleName", "LastName", "Email");

                    foreach (var student in students)
                    {
                        table.AddRow(student.Id, student.StudentCode, student.FirstName, student.MiddleName, student.LastName, student.Email);
                    }
                    Console.WriteLine("");

                    table.Write(Format.Default);

                    return;
                }

                Helpers.InfoTextOutput("No records found");
            }
            catch (Exception ex)
            {
                Helpers.FailureTextOutput(ex.Message);
            }
        }


        public async Task GetStudentById()
        {
            try
            {
                Console.WriteLine("Enter student id: ");
                int studentId = int.Parse(Console.ReadLine()!);

                var students = await _studentRepository.GetStudentById(studentId);

                if (students is not null && students.Id == studentId)
                {
                    var table = new ConsoleTable("ID","STUDENTCODE", "FIRSTNAME", "MIDDLENAME","LASTNAME","EMAIL","GENDER","DATEOFBIRTH", "DATEADDED", "LASTMODIFIED");

                    table.AddRow(students.Id, students.StudentCode ,students.FirstName, students.MiddleName, students.LastName, students.Email, students.Gender, students.DateOfBirth, students.DateCreated ,students.LastModified);
                    Console.WriteLine("");
                    table.Write(Format.Alternative);

                    return;
                }

            }
            catch (Exception ex)
            {
                Helpers.FailureTextOutput($"{ex.Message} records not found");
            }
        }

        public async Task GetStudentByCode()
        {
            try
            {
                Console.WriteLine("Enter student code: ");
                string studentCode = Console.ReadLine()!;

                var students = await _studentRepository.GetStudentByCode(studentCode);

                if (students is not null && students.StudentCode == studentCode)
                {
                    var table = new ConsoleTable("ID","STUDENTCODE", "FIRSTNAME", "MIDDLENAME", "LASTNAME", "EMAIL", "GENDER", "DATEOFBIRTH", "DATEADDED", "LASTMODIFIED");

                    table.AddRow(students.Id, students.StudentCode, students.FirstName, students.MiddleName, students.LastName, students.Email, students.Gender, students.DateOfBirth, students.DateCreated, students.LastModified);
                    Console.WriteLine("");
                    table.Write(Format.Alternative);

                    return;
                }

            }
            catch (Exception ex)
            {
                Helpers.FailureTextOutput($"{ex.Message} records not found");
            }
        }

        public async Task DeleteStudent()
        {
            try
            {
                Console.WriteLine("Enter student id: ");
                int dutyId = int.Parse(Console.ReadLine()!);

                var deleted = await _studentRepository.DeleteStudent(dutyId);

                if (deleted)
                {

                    Helpers.SuccessTextOutput($"Student deleted successfully!");
                }
                else
                {
                    Helpers.FailureTextOutput("Could not delete student");
                }
            }
            catch (Exception ex)
            {
                Helpers.FailureTextOutput(ex.Message);
            }
        }

        public async Task UpdateStudent()
        {
            try
            {

                Console.Write("Enter the student Id: ");
                int studentId = int.Parse(Console.ReadLine()!);
                var student = _studentRepository.GetStudentById(studentId);

                if (student is not null)
                {
                    Console.Write("Enter First Name: ");
                    string firstName = Console.ReadLine()!;

                    Console.Write("Enter Middle Name: ");
                    string? middleName = Console.ReadLine();

                    Console.Write("Enter Last Name: ");
                    string lastName = Console.ReadLine()!;
                    Console.Write("Enter email: ");
                    string email = Console.ReadLine()!;

                    int gender = Helpers.SelectEnum("Enter student gender:\nEnter 1 for Male\nEnter 2 for Female: ", 1, 2);
                    var Gender = (Gender)gender;

                    Console.Write("Enter date of birth (2003-12-25): ");
                    var dob = Helpers.TryParseDateTimeOnly(Console.ReadLine()!);

                    var students = new UpdateStudentDto
                    {
                        Id = studentId,
                        FirstName = firstName,
                        LastName = lastName,
                        MiddleName = middleName,
                        Email = email,
                        Gender = Gender,
                        DateOfBirth = dob,
                        LastModified = new DateTime(01, 01, 0001)
                    };

                    int rowsAffected = await _studentRepository.UpdateStudent(students);

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("");
                        Helpers.SuccessTextOutput("Student record updated successfully!");
                    }
                    else
                    {
                        Helpers.FailureTextOutput("Student record does not exist!");
                    }
                }
            }
            catch (Exception ex)
            {
                Helpers.FailureTextOutput(ex.Message);
            }
        }
    }
}
