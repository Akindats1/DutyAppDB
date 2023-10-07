namespace DutyAppDB.Services.Contracts
{
    public interface IStudentService
    {
        Task AddStudent();
        Task GetAllStudent();
        Task GetStudentById();
        Task GetStudentByCode();
        Task DeleteStudent();
        Task UpdateStudent();
    }
}
