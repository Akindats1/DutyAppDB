using Dapper;
using DutyAppDB.Models.Dtos.DutyAssignment;
using DutyAppDB.Models.Dtos.Student;
using DutyAppDB.Models.Entities;
using DutyAppDB.Repositories.Contracts;
using System.Data;
using System.Xml.Linq;

namespace DutyAppDB.Repositories
{
    public class DutyAssignmentRepository : IDutyAssignmentRepository
    {
        private readonly IDbConnection _dbConnection;
        public List<DutyAssignment> dutyAssignments = new List<DutyAssignment>();

        public DutyAssignmentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> CreateDutyAssignment(CreateDutyAssignmentDto request)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();
                var maxId = await _dbConnection.ExecuteScalarAsync<int>("SELECT MAX(Id) FROM Student");
                var id = maxId + 1;

                var dutyAssign = new DutyAssignment
                {
                    Id = id,
                    DutyId = request.DutyId,
                    StudentId = request.StudentId,
                    StudentCode = request.StudentCode,
                    StudentName = request.StudentName,
                    DutyName = request.DutyName,
                    DateCreated = DateTime.Now
                };

                var sql = "INSERT INTO dutyassignment ( DutyId, StudentId, StudentCode, StudentName, DutyName, DateCreated) VALUES (@DutyId, @StudentId, @StudentCode, @StudentName, @DutyName, @DateCreated);";

                int rowsAffected = await _dbConnection.ExecuteAsync(sql, dutyAssign);

                return rowsAffected;
            }
        }

        public async Task<List<ReadOnlyDutyAssignmentDto>> GetAllDutyAssignment()
        {
            using (_dbConnection)
            {
                _dbConnection.Open();

                var sql = "SELECT Id, DutyId, StudentCode, StudentName, DutyName FROM dutyassignment;";

                var result = await _dbConnection.QueryAsync<ReadOnlyDutyAssignmentDto>(sql);

                return result.ToList();
            }
        }

        public async Task<ViewDutyAssignmentDetailDto> GetDutyAssignmentById(int id)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();

                var dutyAssignment = await _dbConnection.QuerySingleAsync<ViewDutyAssignmentDetailDto>("SELECT * FROM dutyassignment  WHERE Id = @Id", new { Id = id });

                return dutyAssignment;
            }
        }


        public async Task<ViewDutyAssignmentDetailDto> GetDutyAssignmentByDutyName(string name)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();

                var dutyAssignment = await _dbConnection.QuerySingleAsync<ViewDutyAssignmentDetailDto>("SELECT * FROM dutyassignment WHERE DutyName = @DutyName", new { DutyName = name });

                return dutyAssignment;
            }
        }

        public async Task<bool> DeleteDutyAssignment(int id)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();
                var affectedrows = await _dbConnection.ExecuteAsync("DELETE FROM dutyassignment WHERE ID = @Id", new { Id = id });
                return affectedrows > 0;
            }
        }

        public async Task<int> UpdateDutyAssignment(UpdateDutyAssignmentDto request)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();

                var sql = "UPDATE dutyassignment SET DutyId = @DutyId, StudentId = @StudentId, DutyName = @DutyName WHERE Id = @Id";

                var rowsAffected = await _dbConnection.ExecuteAsync(sql, request);

                return rowsAffected;
            }
        }

        public async Task<ViewDutyAssignmentDetailDto> GetDutyAssignmentByStudentCode(string code)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();

                var dutyAssignment = await _dbConnection.QuerySingleAsync<ViewDutyAssignmentDetailDto>("SELECT * FROM dutyassignment WHERE StudentCode = @StudentCode", new { StudentCode = code });

                return dutyAssignment;
            }
        }
    }
}
