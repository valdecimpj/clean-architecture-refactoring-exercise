using System.Diagnostics;
using Infrastructure.Data;
using Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();
builder.Services.AddScoped<ExceptionHandlerMiddleware>();
builder.Services.RegisterDirtyStoreModule(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DirtyStoreDbContext>();
    await dbContext.Database.EnsureCreatedAsync();
}

app.UseSwagger();
app.UseSwaggerUI();
app.MapOpenApi();

if (!app.Environment.IsDevelopment())
    app.Lifetime.ApplicationStarted.Register(() =>
    {
        try
        {
            Process.Start(
                new ProcessStartInfo
                {
                    FileName = "http://localhost:5000/swagger",
                    UseShellExecute = true,
                }
            );
        }
        catch
        {
            app.Services.CreateScope()
                .ServiceProvider.GetRequiredService<ILogger<Program>>()
                .LogWarning(
                    "Failed to open browser automatically. Please navigate to http://localhost:5000/swagger"
                );
        }
    });

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.MapControllers();

app.Run();
