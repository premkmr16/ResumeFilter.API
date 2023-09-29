using Microsoft.EntityFrameworkCore;
using ResumeFilter.API.Context;
using ResumeFilter.API.Repositories;
using ResumeFilter.API.Repositories.IRepositories;
using ResumeFilter.API.Services;
using ResumeFilter.API.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ResumeFilterDbContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("RFConnection")));

builder.Services.AddScoped<ICommonRepository, CommonRepository>();
builder.Services.AddTransient<ICommonService, CommonService>();

builder.Services.AddCors(options =>
		options.AddPolicy("AllowAll",
			builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
