
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using StudentApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
app.UseExceptionHandler("/Error");
app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting(); 
app.MapRazorPages();

TestDatabaseConnection(app);

app.Run();

void TestDatabaseConnection(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {

        var services = scope.ServiceProvider;
        try
        {

            var context =
            services.GetRequiredService<ApplicationDbContext>();
  
            if (context.Database.CanConnect())
            {
                Console.WriteLine("Connection to the database successful!");
            }
            else
            {
                Console.WriteLine("Failed to connect to the database.");
            }
        }
        catch (Exception ex)
        {
 
            Console.WriteLine($"An exception occurred: {ex.Message}");
        }
    }
}