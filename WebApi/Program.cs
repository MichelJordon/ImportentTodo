using Infrastucture.Context;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Infrastucture.Meppers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<TodoService>();
builder.Services.AddScoped<TodoListService>();
builder.Services.AddScoped<TodoListImagesService>();
builder.Services.AddAutoMapper(typeof(ServicesProfile));
// Add services to the container.
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(op => op.UseNpgsql(connection));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
