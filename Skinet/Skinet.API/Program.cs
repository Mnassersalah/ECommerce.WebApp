using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Skinet.API.Extensions;
using Skinet.API.Middlewares;
using Skinet.Infrastructure.Data;
using Skinet.Infrastructure.Data.DataSeed;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var config = builder.Configuration;
builder.Services.AddDbContext<StoreContext>(optionsBuilder => 
    optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection")));

builder.Services.AddSkinetServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Migrate DB
using (var scope = app.Services.CreateScope())
{
	var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
	try
	{
		logger.LogInformation("start migratin DB");
		var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
		await context.Database.MigrateAsync();
		await DataSeed.SeedDataAsync(context, logger);
	}
	catch (Exception ex)
	{
		logger.LogError(ex, "Error happened during Migrating DB.");
	}
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionMiddleware();
//app.UseExceptionHandler($"/error/{StatusCodes.Status500InternalServerError}");

app.UseStatusCodePagesWithReExecute("/error/{0}");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
