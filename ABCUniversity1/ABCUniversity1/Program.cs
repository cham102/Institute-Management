using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ABCUniversity1.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ABCUniversity1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ABCUniversity1Context") ?? throw new InvalidOperationException("Connection string 'ABCUniversity1Context' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ABCUniversity1Context>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
