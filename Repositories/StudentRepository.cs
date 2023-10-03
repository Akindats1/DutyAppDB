using Dapper;
using DutyAppDB.Models.Dtos.Student;
using DutyAppDB.Models.Entities;
using DutyAppDB.Repositories.Contracts;
using System.Data;

namespace DutyAppDB.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbConnection _dbConnection;

        public StudentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> AddStudent(AddStudentDto request)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();

                var sql = "INSERT INTO student (StudentCode, FirstName, MiddleName, LastName, Email, DateOfBirth, Gender) VALUES (@StudentCode, @FirstName, @MiddleName, @LastName, @Email, @DateOfBirth, @Gender);";

                int rowsAffected = await _dbConnection.ExecuteAsync(sql, request);

                return rowsAffected;
            }
        }
    }
}
