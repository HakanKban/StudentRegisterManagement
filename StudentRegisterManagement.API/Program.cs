using Microsoft.EntityFrameworkCore;
using StudentRegisterManagement.Core;
using StudentRegisterManagement.Core.Interfaces;
using StudentRegisterManagement.Data;
using StudentRegisterManagement.Data.Repository;
using StudentRegisterManagement.Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyContext>(x =>
{
    x.UseSqlite(builder.Configuration.GetConnectionString("StudentRegisterDatabase"), opt =>
    {
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(MyContext)).GetName().Name);
    });
});
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
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
