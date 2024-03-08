 
using Blazor.Live.Database.Data;
using Blazor.Live.Database.Hubs;
using Blazor.Live.Database.Pages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;
namespace Blazor.Live.Database.Service
{
    public class vwProvinceService
    {
        private readonly IHubContext<vwProvinceHub> _context;
        AppDbContext dbContext = new AppDbContext();
        private readonly SqlTableDependency<vwProvince> _dependency;
        private readonly string _connectionString;

        public vwProvinceService(IHubContext<vwProvinceHub> context)
        {
            _context = context;
            _connectionString = "Server=DESKTOP-PK86BAT;Database=ETR-IS-PGA-TEST;User Id=awit;Password=awit;Trusted_Connection=True;MultipleActiveResultSets=true";
            _dependency = new SqlTableDependency<vwProvince>(_connectionString, "vwProvince", "dbo");
            _dependency.OnChanged += Changed;
            _dependency.Start();
      }
 
        private async void Changed(object sender, RecordChangedEventArgs<vwProvince> e)
        {
            var vwProvince = await GetAllvwProvince();
            await _context.Clients.All.SendAsync("RefreshvwProvince", vwProvince);
            // int value = 0;
            //  throw new NotImplementedException();
        }
        public async Task<List<vwProvince>> GetAllvwProvince()
        {
            return await dbContext.vwProvince.AsNoTracking().ToListAsync();
        }
    }
}
