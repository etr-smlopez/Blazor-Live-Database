 
using Blazor.Live.Database.Data;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;
namespace Blazor.Live.Database.Hubs
{
    public class vwProvinceHub : Hub
    {
        public async Task RefreshvwProvince(List<vwProvince> vwProvince)
        {
            await Clients.All.SendAsync("RefreshvwProvince", vwProvince);
        }
    }
}
