using interbank_app;
using interbank_data.Source.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options => options.AddPolicy(name: "interbank-app",
    policy =>
    {
        policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    }
    )
);

builder.Services.AddDbContext<InterbankDbContext>(
    par => par.UseSqlServer(
    builder.Configuration.GetConnectionString("DevelopmentDb"),
    b => b.MigrationsAssembly("interbank-app"))
    );

builder.Services.AddMyServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("interbank-app");

app.UseAuthorization();

app.MapControllers();

app.Run();
