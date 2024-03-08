using Blazor.Live.Database.Data;
using Blazor.Live.Database.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;
namespace Blazor.Live.Database.Service
{
    public class EmployeeService
    {
        private readonly IHubContext<EmployeesHub> _context;
        AppDbContext dbContext = new AppDbContext();
        private readonly SqlTableDependency<Employees> _dependency;
        private readonly string _connectionString;
 
        public EmployeeService(IHubContext<EmployeesHub> context)
        {
            _context = context;
            _connectionString = "Server=DESKTOP-PK86BAT;Database=ETR-IS-PGA-TEST;User Id=awit;Password=awit;Trusted_Connection=True;MultipleActiveResultSets=true";
            _dependency = new SqlTableDependency<Employees>(_connectionString, "Employees");
            _dependency.OnChanged += Changed;
            _dependency.Start(); 
        }

        private async void Changed(object sender, RecordChangedEventArgs<Employees> e)
        {
            var employees = await GetAllEmployees();
            await _context.Clients.All.SendAsync("RefreshEmployees", employees);
            // int value = 0;
            //  throw new NotImplementedException();
        }
        public async Task<List<Employees>> GetAllEmployees()
        {
            return await dbContext.Employees.AsNoTracking().ToListAsync();
        }
    }
}
