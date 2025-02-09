using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetSchool.DAL.EF
{

    public class InternetSchoolDBContextFactory : IDesignTimeDbContextFactory<InternetSchoolDBContext>
    {
        public InternetSchoolDBContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=DESKTOP-S7D9M3G\\SQLEXPRESS;Database=InternetSchoolDB;Integrated Security=true;TrustServerCertificate=true;";

            var optionsBuilder = new DbContextOptionsBuilder<InternetSchoolDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new InternetSchoolDBContext(optionsBuilder.Options);
        }
    }
}
