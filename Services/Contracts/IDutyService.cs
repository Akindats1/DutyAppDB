namespace DutyAppDB.Services.Contracts;

public interface IDutyService
{
    Task CreateDuty();
    Task GetAllDuty();
}
