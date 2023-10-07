using ConsoleTables;
using DutyAppDB.Models.Dtos.DutyAssignment;
using DutyAppDB.Repositories.Contracts;
using DutyAppDB.Services.Contracts;
using DutyAppDB.Shared;

namespace DutyAppDB.Services
{
    public class DutyAssignmentService : IDutyAssignmentService
    {
        private readonly IDutyAssignmentRepository _dutyAssignmentRepository;
        private readonly IDutyRepository _dutyRepository;
        private readonly IStudentRepository _studentRepository;

        public DutyAssignmentService(IDutyAssignmentRepository dutyAssignmentRepository, IDutyRepository dutyRepository, IStudentRepository studentRepository)
        {
            _dutyAssignmentRepository = dutyAssignmentRepository;
            _dutyRepository = dutyRepository;
            _studentRepository = studentRepository;
        }

        public async Task CreateDutyAssignment()
        {
           try
           {
                Console.WriteLine("Enter duty id: ");
                int dutyId = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Enter student code: ");
                string studentCode = Console.ReadLine()!;

                var student = await _studentRepository.GetStudentByCode(studentCode);
                var duty = await _dutyRepository.GetDuty(dutyId);


                var dutyAssign = new CreateDutyAssignmentDto
                {
                    DutyId = dutyId,
                    StudentCode = studentCode,
                    StudentName = $"{student.FirstName} {student.LastName}",
                    DutyName = duty.Name
                };

                int rowsAffected = await _dutyAssignmentRepository.CreateDutyAssignment(dutyAssign);

                if (duty == null || student == null)
                {
                    Console.WriteLine("Student or duty does not exist");
                    return;
                }

                if (rowsAffected == 1)
                {
                    Helpers.SuccessTextOutput($"Duty assigned to {student.FirstName} {student.LastName} successfully!");
                }
                else
                {
                    Helpers.FailureTextOutput("Could not assign to student!");
                }
           }
           catch (Exception ex)
           {
                Helpers.FailureTextOutput(ex.Message);
           }
        }

        public async Task GetAllDutyAssignment()
        {
            try
            {
                var dutyAssignments = await  _dutyAssignmentRepository.GetAllDutyAssignment();

                if (dutyAssignments.Count > 0)
                {
                    var table = new ConsoleTable("ID", "StudentCode", "StudentName", "DutyName");

                    foreach (var dutyAssign in dutyAssignments)
                    {
                        table.AddRow(dutyAssign.Id, dutyAssign.StudentCode, dutyAssign.StudentName, dutyAssign.DutyName);
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

        public async Task DeleteDutyAssignment()
        {
            try
            {
                Console.WriteLine("Enter duty assignment id: ");
                int dutyAssignmentId = int.Parse(Console.ReadLine()!);

                var deleted = await _dutyAssignmentRepository.DeleteDutyAssignment(dutyAssignmentId);

                if (deleted)
                {
                    Helpers.SuccessTextOutput($"Duty asssignment deleted successfully!");
                }
                else
                {
                    Helpers.FailureTextOutput("Could not delete assignment");
                }
            }
            catch (Exception ex)
            {
                Helpers.FailureTextOutput(ex.Message);
            }
        }

        public async Task GetDutyAssignment()
        {
            try
            {
                Console.WriteLine("Enter duty name: ");
                string dutyName = Console.ReadLine()!;

                var dutyAssignment = await _dutyAssignmentRepository.GetDutyAssignmentByDutyName(dutyName);

                if (dutyAssignment is not null && dutyAssignment.DutyName == dutyName)
                {
                    var table = new ConsoleTable("ID", "STUDENTCODE", "STUDENTNAME","DUTYNAME","DATEASSIGNED", "LASTMODIFIED");

                    table.AddRow(dutyAssignment.Id, dutyAssignment.StudentCode, dutyAssignment.StudentName, dutyAssignment.DutyName, dutyAssignment.DateCreated, dutyAssignment.LastModified);
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

        public async Task UpdateDutyAssignment()
        {
            try
            {

                Console.Write("Enter duty assignment Id: ");
                int dutyAssignmentId = int.Parse(Console.ReadLine()!);
                var dutyAssignment = _dutyAssignmentRepository.GetDutyAssignmentById(dutyAssignmentId);

                
                    
                if (dutyAssignment is not null) 
                {
                    Console.Write("Enter the duty id: ");
                    int dutyId = int.Parse(Console.ReadLine()!);

                    Console.Write("Enter the student id: ");
                    int studentId = int.Parse(Console.ReadLine()!);

                    var duty =  await _dutyRepository.GetDuty(dutyId);

                    var dutyAssignmentUpdate = new UpdateDutyAssignmentDto
                    {
                       Id = dutyAssignmentId,
                       DutyId = dutyId,
                       StudentId = studentId,
                       DutyName = duty.Name
                    };

                    int rowsAffected = await _dutyAssignmentRepository.UpdateDutyAssignment(dutyAssignmentUpdate);

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("");
                        Helpers.SuccessTextOutput("Duty assignent updated successfully!");
                    }
                    else
                    {
                        Helpers.FailureTextOutput("Duty assignment does not exist!");
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
