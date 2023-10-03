using ConsoleTables;
using DutyAppDB.Models.Dtos.Duty;
using DutyAppDB.Repositories.Contracts;
using DutyAppDB.Services.Contracts;
using DutyAppDB.Shared;

namespace DutyAppDB.Services;

public class DutyService : IDutyService
{
    private readonly IDutyRepository _dutyRepository;

    public DutyService(IDutyRepository dutyRepository)
    {
        _dutyRepository = dutyRepository;
    }

    public async Task CreateDuty()
    {
        try
        {
            Console.Write("Enter the Duty Name: ");
            string dutyName = Console.ReadLine()!;

            Console.Write("Enter the Duty Description: ");
            string? description = Console.ReadLine();

            var duty = new CreateDutyDto
            {
                Name = dutyName,
                Description = description
            };

            int rowsAffected = await _dutyRepository.CreateDuty(duty);

            if (rowsAffected == 1)
            {
                Helpers.SuccessTextOutput("Duty created successfully!");
            }
            else
            {
                Helpers.FailureTextOutput("Could not create duty!");
            }
        }
        catch (Exception ex)
        {
            Helpers.FailureTextOutput(ex.Message);
        }
    }

    public async Task GetAllDuty()
    {
        try
        {
            var duties = await _dutyRepository.GetAllDuty();

            if (duties.Count > 0)
            {
                var table = new ConsoleTable("ID","DUTY NAME", "DESCRIPTION");

                foreach (var duty in duties)
                {
                    table.AddRow(duty.Id, duty.Name, duty.Description);
                }
                Console.WriteLine("");

                table.Write(Format.Alternative);

                return;
            }

            Helpers.InfoTextOutput("No records found");
        }
        catch (Exception ex)
        {
            Helpers.FailureTextOutput(ex.Message);
        }
    }

    public async Task DeleteDuty()
    {
       try
       {
            Console.WriteLine("Enter duty id: ");
            int dutyId = int.Parse(Console.ReadLine()!);

            var deleted = await _dutyRepository.DeleteDuty(dutyId);

            if (deleted)
            {

                Helpers.SuccessTextOutput($"Duty deleted successfully!");
            }
            else
            {
                Helpers.FailureTextOutput("Could not delete duty");
            }
       }
       catch(Exception ex) 
       {
            Helpers.FailureTextOutput(ex.Message);
       }
    }

    public async Task GetDuty()
    {
        try
        {
            Console.WriteLine("Enter duty id: ");
            int dutyId = int.Parse(Console.ReadLine()!);

            var duties = await _dutyRepository.GetDuty(dutyId);

            if (duties is not null && duties.Id == dutyId)
            {
                var table = new ConsoleTable("ID", "DUTY NAME", "DESCRIPTION", "DATECREATED", "LASTMODIFIED");

                table.AddRow(duties.Id, duties.Name, duties.Description, duties.DateCreated, duties.LastModified);
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

    public async Task UpdateDuty()
    {
        try
        {

            Console.Write("Enter the Duty Id: ");
            int dutyId = int.Parse(Console.ReadLine()!);
            var duty = _dutyRepository.GetDuty(dutyId);

            if (duty is not null)
            {
                Console.Write("Enter the Duty Name: ");
                string dutyName = Console.ReadLine()!;

                Console.Write("Enter the Duty Description: ");
                string? description = Console.ReadLine();

                var dutyUpdate = new UpdateDutyDto
                {
                    Id = dutyId,
                    Name = dutyName,
                    Description = description
                };

                int rowsAffected = await _dutyRepository.UpdateDuty(dutyUpdate);

                if (rowsAffected > 0)
                {
                    Console.WriteLine("");
                    Helpers.SuccessTextOutput("Duty updated successfully!");
                }
                else
                {
                    Helpers.FailureTextOutput("Duty does not exist!");
                }
            }
        }
        catch (Exception ex)
        {
            Helpers.FailureTextOutput(ex.Message);
        }
    }
}
