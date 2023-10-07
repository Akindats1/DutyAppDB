using DutyAppDB.Models.Dtos.DutyAssignment;


namespace DutyAppDB.Repositories.Contracts
{
    public interface IDutyAssignmentRepository
    {
        Task<int> CreateDutyAssignment(CreateDutyAssignmentDto request);
        Task<List<ReadOnlyDutyAssignmentDto>> GetAllDutyAssignment();
        Task<ViewDutyAssignmentDetailDto> GetDutyAssignmentById(int id);
        Task<ViewDutyAssignmentDetailDto> GetDutyAssignmentByDutyName(string name);
        Task<ViewDutyAssignmentDetailDto> GetDutyAssignmentByStudentCode(string code);
        Task<bool> DeleteDutyAssignment(int id);
        Task<int> UpdateDutyAssignment(UpdateDutyAssignmentDto request);
    }
}
