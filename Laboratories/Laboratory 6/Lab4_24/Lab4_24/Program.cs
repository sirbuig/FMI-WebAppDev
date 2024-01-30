using Lab4_24.Data;
using Lab4_24.Helpers.Extensions;
using Lab4_24.Helpers.Seeders;
using Lab4_24.Services.UserService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<Lab4Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddRepositories();
builder.Services.AddServices();

/*
// Created each time they are requested.
builder.Services.AddTransient<IUserService, UserService>();
// Created once per client request.
builder.Services.AddScoped<IUserService, UserService>();
// Created on the first request.
builder.Services.AddSingleton<IUserService, UserService>();
*/

var app = builder.Build();
SeedData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<UsersSeeders>();
        service.SeedInitialUsers();
    }
}