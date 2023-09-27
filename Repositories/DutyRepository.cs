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
}
