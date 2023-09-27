using DutyAppDB.Models.Dtos.Duty;

namespace DutyAppDB.Repositories.Contracts;

public interface IDutyRepository
{
    Task<int> CreateDuty(CreateDutyDto request);
    Task<List<ReadOnlyDutyDto>> GetAllDuty();
}
