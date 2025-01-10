
using Litemir_CouseWork_DataBase_Postgres;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LearningDbContext>(
    options =>
    {
        options.UseNpgsql(configuration.GetConnectionString(nameof(LearningDbContext)));
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.Run();
