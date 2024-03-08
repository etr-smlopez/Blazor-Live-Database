using Blazor.Live.Database.Data;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;
namespace Blazor.Live.Database.Hubs
{
    public class EmployeesHub : Hub
    {
        public async Task RefreshEmployees(List<Employees> Employees)
        {
            await Clients.All.SendAsync("RefreshEmployees", Employees);
        }
    }
}
