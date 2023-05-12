using Microsoft.EntityFrameworkCore;
using Questions_Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//registering datacontext class as a service in the dependency injection container using the Adddbcontext method provide by Iservicecollertion interface
//AddDbcontext method takes the type parameter represednting the Dbcontext subclass to register datacontext and configuration delegate
//this code configure datacontext to use micorsoft sql server as the database provider and specify the connection string/
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
