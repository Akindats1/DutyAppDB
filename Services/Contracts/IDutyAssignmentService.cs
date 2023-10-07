namespace DutyAppDB.Services.Contracts
{
    public interface IDutyAssignmentService
    {
        Task CreateDutyAssignment();
        Task GetAllDutyAssignment();
        Task DeleteDutyAssignment();
        Task GetDutyAssignment();
        Task UpdateDutyAssignment();
    }
}
