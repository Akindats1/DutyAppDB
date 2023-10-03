using DutyAppDB.Models.Dtos.Duty;

namespace DutyAppDB.Repositories.Contracts;

public interface IDutyRepository
{
    Task<int> CreateDuty(CreateDutyDto request);
    Task<List<ReadOnlyDutyDto>> GetAllDuty();
    Task<bool> DeleteDuty(int id);
    Task<ViewDutyDetailDto> GetDuty(int id);
    Task<int> UpdateDuty(UpdateDutyDto request);
}
