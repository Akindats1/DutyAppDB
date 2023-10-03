namespace DutyAppDB.Services.Contracts;

public interface IDutyService
{
    Task CreateDuty();
    Task GetAllDuty();
    Task DeleteDuty();
    Task GetDuty();
    Task UpdateDuty();
}
