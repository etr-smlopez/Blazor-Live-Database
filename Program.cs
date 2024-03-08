using Blazor.Live.Database;
using Blazor.Live.Database.Data;
using Blazor.Live.Database.Hubs;
using Blazor.Live.Database.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<EmployeeService>();
builder.Services.AddSingleton<vwProvinceService>();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "applicaion/octet-stream" });
});
var app = builder.Build();
app.UseResponseCompression
    ();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapHub<EmployeesHub>("/employeeshub");
app.MapHub<vwProvinceHub>("/vwprovincehub");
app.MapFallbackToPage("/_Host");

app.Run();
