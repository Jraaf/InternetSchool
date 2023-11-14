using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Databases
{
    public partial class InternetSchoolDBContext
    {
        public class InternetSchoolDBContextFactory : IDesignTimeDbContextFactory<InternetSchoolDBContext>
        {
            public InternetSchoolDBContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<InternetSchoolDBContext>();
                optionsBuilder.UseSqlServer("Server=DESKTOP-S7D9M3G\\SQLEXPRESS;Database=InternetSchoolDB;Integrated Security=true;TrustServerCertificate=true;");
                return new InternetSchoolDBContext(optionsBuilder.Options);
            }
        }
    }
}