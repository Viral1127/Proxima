using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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
builder.Services.AddScoped<ProjectAttachmentsRepository>();
builder.Services.AddScoped<AdminDashboardRepository>();
var corsPolicy = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
        policy =>
        {
            policy.WithOrigins("https://localhost:7068") // Allow frontend origin
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        });
});



builder.Services.AddControllers()
    .AddFluentValidation(fv =>
        fv.RegisterValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() }));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "UserAuthCookie";
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromHours(2);
        options.Cookie.SameSite = SameSiteMode.None; // For cross-origin requests
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Use if using HTTPS
    });
builder.Services.AddAuthorization();

builder.Services.AddScoped<AuthRepository>();

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "https://localhost:7068");
        ctx.Context.Response.Headers.Append("Access-Control-Allow-Methods", "GET, HEAD, OPTIONS");
    }
});


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(corsPolicy);
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
