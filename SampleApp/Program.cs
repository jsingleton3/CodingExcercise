using System.Configuration;
using SampleApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register the doctor service and client
builder.Services.Add(new ServiceDescriptor(typeof(IDoctorService), typeof(DoctorService), ServiceLifetime.Scoped));

builder.Services.AddHttpClient("DoctorClient", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["BaseAddress"]);
    c.DefaultRequestHeaders.Add("Accept", "application/json");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

