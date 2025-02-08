using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Proxima.Data;
using Proxima.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("https://localhost:7068") // Change this to match your frontend URL
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});
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
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        // Allow null origin (file://) and other specific origins like localhost
        policy.SetIsOriginAllowed(origin => origin.StartsWith("https://localhost:7068"))//origin == null || origin.StartsWith("file://")
              .AllowAnyHeader() // Allow all headers
              .AllowAnyMethod() // Allow all HTTP methods (GET, POST, PUT, DELETE, PATCH)
              .AllowCredentials(); // If credentials are required
    });
});

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
app.UseCors("AllowFrontend");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseCors("AllowSpecificOrigin"); // Apply CORS middleware
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
