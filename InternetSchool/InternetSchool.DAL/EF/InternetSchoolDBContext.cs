using InternetSchool.DAL.Models;
using InternetSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetSchool.DAL.EF
{
    public partial class InternetSchoolDBContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        public InternetSchoolDBContext(DbContextOptions<InternetSchoolDBContext> options)
            : base(options)
        {
        }
    }
}