using Dapper;
using DutyAppDB.Models.Dtos.Student;
using DutyAppDB.Models.Entities;
using DutyAppDB.Repositories.Contracts;
using DutyAppDB.Shared;
using Org.BouncyCastle.Asn1.X509;
using System.Data;

namespace DutyAppDB.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbConnection _dbConnection;
        public List<Student> students = new List<Student>();

        public StudentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> AddStudent(AddStudentDto request)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();
                var maxId = await _dbConnection.ExecuteScalarAsync<int>("SELECT MAX(Id) FROM Student");
                var id = maxId + 1;
                string code = Helpers.GenerateCode(id);

                var student = new Student
                {
                    Id = id,
                    StudentCode = code,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    MiddleName = request.MiddleName,
                    Email = request.Email,
                    DateOfBirth = request.DateOfBirth,
                    Gender = request.Gender,
                    DateCreated = DateTime.Now
                };

                var sql = "INSERT INTO student (StudentCode, FirstName, MiddleName, LastName, Email, DateOfBirth, Gender) VALUES (@StudentCode, @FirstName, @MiddleName, @LastName, @Email, @DateOfBirth, @Gender)";

                int rowsAffected = await _dbConnection.ExecuteAsync(sql, student);

                return rowsAffected;
            }
        }

        public async Task<List<ReadOnlyStudentDto>> GetAllStudent()
        {
            using (_dbConnection)
            {
                _dbConnection.Open();

                var sql = "SELECT Id, StudentCode, FirstName, MiddleName, LastName, Email  FROM student;";

                var result = await _dbConnection.QueryAsync<ReadOnlyStudentDto>(sql);

                return result.ToList();
            }
        }

        public async Task<ViewStudentDetailDto> GetStudentById(int id)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();
                
                var student = await _dbConnection.QuerySingleAsync<ViewStudentDetailDto>("SELECT * FROM student  WHERE Id = @Id", new { Id = id });

                return student;
            }
        }

        public async Task<ViewStudentDetailDto> GetStudentByCode(string code)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();

                var student = await _dbConnection.QuerySingleAsync<ViewStudentDetailDto>("SELECT * FROM student  WHERE StudentCode = @StudentCode", new { StudentCode = code });

                return student;
            }
        }

        public async Task<bool> DeleteStudent(int id)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();
                var affectedrows = await _dbConnection.ExecuteAsync("DELETE FROM student WHERE Id = @Id", new { Id = id });
                return affectedrows > 0;
            }
        }

        public async Task<int> UpdateStudent(UpdateStudentDto request)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();

                var sql = "UPDATE student SET FirstName = @FirstName, LastName = @LastName, MiddleName = @MiddleName, Email = @Email, Gender = @Gender, DateOfBirth = @DateOfBirth WHERE Id = @Id && StudentCode = StudentCode";

                var rowsAffected = await _dbConnection.ExecuteAsync(sql, request);

                return rowsAffected;
            }
        }
    }
}
