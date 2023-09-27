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
                var table = new ConsoleTable("DUTY NAME", "DESCRIPTION");

                foreach (var duty in duties)
                {
                    table.AddRow(duty.Name, duty.Description);
                }

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
}
