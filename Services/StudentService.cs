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
        public List<Student> students = new List<Student>();

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task AddStudent()
        {
            try
            {
                int id = students.Count != 0 ? students[students.Count - 1].Id + 1 : 1;
                string code = Helpers.GenerateCode(id);

                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine()!;

                Console.Write("Enter Middle Name: ");
                string? middleName = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine()!;
                Console.Write("Enter email: ");
                string email = Console.ReadLine()!;

                int gender = Helpers.SelectEnum("Enter employee gender:\nEnter 1 for Male\nEnter 2 for Female: ", 1, 2);
                var Gender = (Gender)gender;

                Console.Write("Enter date of birth (2003-12-25): ");
                var dob = Helpers.TryParseDateTimeOnly(Console.ReadLine()!);
                
                Console.Write("Enter date joined (2003-12-25): ");
                var joinedDate = Helpers.TryParseDateTimeOnly(Console.ReadLine()!);



                var student = new AddStudentDto
                {
                    StudentCode = code,
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    Email = email,
                    Gender = Gender,
                    DateOfBirth = dob,
                    DateCreated = joinedDate
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
    }
}
