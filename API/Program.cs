using API.Extensions;
using API.Helpers;
using API.Middleware;
using Core.Entities.Identity;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BaseDbContext>(x =>
    x.UseSqlite(configuration.GetConnectionString("BaseConnection")));

builder.Services.AddDbContext<AppIdentityDbContext>(x =>
    x.UseSqlite(configuration.GetConnectionString("IdentityConnection")));

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(configuration);

//builder.Services.AddScoped<ITokenService, TokenService>();


builder.Services.AddSwaggerDocumentation();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseSwaggerDocumentation();
app.UseStatusCodePagesWithReExecute("/errors/{0}");


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
try
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var identityContext = services.GetRequiredService<AppIdentityDbContext>();
        /*await identityContext.Database.MigrateAsync();
        await AppIdentityDbContextSeed.SeedUsersAsync(userManager);  */

        var context = services.GetRequiredService<BaseDbContext>();
        await context.Database.MigrateAsync();
        await BaseDbContextSeed.SeedAsync(context, loggerFactory);
        
    }
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "An error occurred during migration");
}

app.Run();
