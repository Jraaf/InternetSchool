using InternetSchool.Extensions;
using InternetScool.BLL.Profiles;
using InternetScool.BLL.Service;
using InternetScool.BLL.Service.Interfaces;
using InternetShcool.DAL.EF;
using InternetShcool.DAL.Repository;
using InternetShcool.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbServices(builder.Configuration);

builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c=>c.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

