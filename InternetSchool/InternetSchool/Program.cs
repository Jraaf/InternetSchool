using AutoMapper;
using InternetSchool.Identity;
using InternetSchool.Swagger;
using InternetScool.BLL.Profiles;
using InternetScool.BLL.Service;
using InternetScool.BLL.Service.Interfaces;
using InternetShcool.DAL.EF;
using InternetShcool.DAL.Repository;
using InternetShcool.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAutoMapper(typeof(GroupProfile));
// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters { };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(IdentityData.AdminUserPolicyName, p =>
        p.RequireClaim(IdentityData.AdminUserClaimName, "true"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>,ConfigureSwaggerOptions>();

//repositories
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

//services
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

builder.Services.AddDbContext<InternetSchoolDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InternetSchoolConnection"));
});

builder.Services.AddAutoMapper(typeof(SchoolProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

