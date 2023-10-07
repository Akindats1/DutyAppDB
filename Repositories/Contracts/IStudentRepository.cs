using DutyAppDB.Models.Dtos.Student;

namespace DutyAppDB.Repositories.Contracts
{
    public interface IStudentRepository
    {
        Task<int> AddStudent(AddStudentDto request);
        Task<List<ReadOnlyStudentDto>> GetAllStudent();
        Task<ViewStudentDetailDto> GetStudentById(int id);
        Task<ViewStudentDetailDto> GetStudentByCode(string code);
        Task<bool> DeleteStudent(int id);
        Task<int> UpdateStudent(UpdateStudentDto request);
    }
}
