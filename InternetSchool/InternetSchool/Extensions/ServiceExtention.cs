using InternetScool.BLL.Profiles;
using InternetScool.BLL.Service.Interfaces;
using InternetScool.BLL.Service;
using InternetShcool.DAL.EF;
using InternetShcool.DAL.Repository.Interfaces;
using InternetShcool.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace InternetSchool.Extensions;

public static class ServiceExtention
{
    /// <summary>
    /// Adds repositoriries, services and dbcontext
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration config)
    {
        // Add services to the container.

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();


        services.AddAutoMapper(typeof(SchoolProfile));
        //repositories
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();

        //services
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<ISchoolService, SchoolService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ISubjectService, SubjectService>();
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<ITokenService, TokenService>();


        services.AddDbContext<InternetSchoolDBContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("InternetSchoolConnection"));
        });

        return services;
    }
}
