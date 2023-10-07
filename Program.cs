using DutyAppDB.Repositories.Contracts;
using DutyAppDB.Repositories;
using DutyAppDB.Services.Contracts;
using DutyAppDB.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System.Data;
using DutyAppDB.Menu;

class Program
{
    static void Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();

        var services = new ServiceCollection();

        services.AddScoped<IDbConnection>(sp =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var connection = new MySqlConnection(connectionString);

            return connection;
        });

        services.AddScoped<IDutyRepository, DutyRepository>();
        services.AddScoped<IDutyService, DutyService>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IDutyAssignmentRepository, DutyAssignmentRepository>();
        services.AddScoped<IDutyAssignmentService, DutyAssignmentService>();


        var serviceProvider = services.BuildServiceProvider();

        var dutyService = serviceProvider.GetRequiredService<IDutyService>();
        var studentService = serviceProvider.GetRequiredService<IStudentService>();
        var dutyAssignmentService = serviceProvider.GetRequiredService<IDutyAssignmentService>();

        Menu.MainMenu(dutyService, studentService, dutyAssignmentService);
    }
}