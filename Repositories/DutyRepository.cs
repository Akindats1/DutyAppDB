using Dapper;
using DutyAppDB.Models.Dtos.Duty;
using DutyAppDB.Repositories.Contracts;
using System.Data;

namespace DutyAppDB.Repositories;

public class DutyRepository : IDutyRepository
{
    private readonly IDbConnection _dbConnection;

    public DutyRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<int> CreateDuty(CreateDutyDto request)
    {
        using (_dbConnection)
        {
            _dbConnection.Open();

            var sql = "INSERT INTO duty (Name, Description) VALUES (@Name, @Description);";

            int rowsAffected = await _dbConnection.ExecuteAsync(sql, request);

            return rowsAffected;
        }
    }

    public async Task<bool> DeleteDuty(int id)
    {
        using(_dbConnection) 
        { 
            _dbConnection.Open();
            var affectedrows = await _dbConnection.ExecuteAsync("DELETE FROM duty WHERE ID = @Id", new { Id = id });
            return affectedrows > 0;
        }
    }

    public async Task<List<ReadOnlyDutyDto>> GetAllDuty()
    {
        using (_dbConnection)
        {
            _dbConnection.Open();

            var sql = "SELECT Id, Name, Description FROM duty;";

            var result = await _dbConnection.QueryAsync<ReadOnlyDutyDto>(sql);

            return result.ToList();
        }
    }

    public async Task<ViewDutyDetailDto> GetDuty(int id)
    {
        using (_dbConnection)
        {
            _dbConnection.Open();

            return await _dbConnection.QuerySingleAsync<ViewDutyDetailDto>("SELECT * FROM Duty WHERE Id = @Id", new { Id = id });

        }
    }
     
    public async Task<int> UpdateDuty(UpdateDutyDto request)
    {
        using (_dbConnection)
        {
            _dbConnection.Open();

            var sql = "UPDATE Duty SET NAME = @Name, DESCRIPTION = @Description WHERE Id = @Id";

            var rowsAffected = await _dbConnection.ExecuteAsync(sql, request);

            return rowsAffected;
        }
    }
}
