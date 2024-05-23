using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LotusOrganiser.Data;
using LotusOrganiser_Repository.Configuration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LotusOrganiserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LotusOrganiser_API")));

builder.Services.ConfigureRepositories();
builder.Services.AddAutoMapper(
    config => config.ShouldUseConstructor = ci => !ci.IsPublic, typeof(Program));

builder.Services.AddSwaggerGen(options =>
{
    options.MapType<FileResult>(() =>
    {
        return new Microsoft.OpenApi.Models.OpenApiSchema
        {
            Type = "string",
            Format = "binary",
        };
    });
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
