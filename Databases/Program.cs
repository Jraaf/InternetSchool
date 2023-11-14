using AutoMapper;
using Databases;
using Databases.Profiles;
using Databases.Service;
using Databases.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ISchoolService, SchoolService>();
builder.Services.AddTransient<ITeacherService, TeacherService>();

builder.Services.AddDbContext<InternetSchoolDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InternetSchoolConnection"));
});


var automapper = new MapperConfiguration(t=> {
    t.AddProfile(new SchoolProfile());
    t.AddProfile(new TeacherProfile());
    t.AddProfile(new GroupProfile());
    t.AddProfile(new StudentProfile());
    t.AddProfile(new SubjectProfile());
});



IMapper mapper =automapper.CreateMapper();
builder.Services.AddSingleton(mapper);

//builder.Services.AddDbContext<HotelContext>(
//    options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelDb"))
//    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();