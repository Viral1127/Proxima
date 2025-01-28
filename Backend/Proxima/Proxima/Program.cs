using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Proxima.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<RolesRepository>();
builder.Services.AddScoped<TeamsRepository>();
builder.Services.AddScoped<ProjectRepository>();
builder.Services.AddScoped<ProjectAssignmentsRepository>();
builder.Services.AddScoped<MilestonesRepository>();
builder.Services.AddScoped<TaskRepository>();
builder.Services.AddScoped<TaskAssignmentRepository>();
builder.Services.AddScoped<TaskTypeRepository>();


builder.Services.AddControllers()
    .AddFluentValidation(fv =>
        fv.RegisterValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() }));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "UserAuthCookie";
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromHours(2);
    });
builder.Services.AddAuthorization();

builder.Services.AddScoped<AuthRepository>();

var app = builder.Build();



app.UseAuthentication();
app.UseAuthorization();

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
