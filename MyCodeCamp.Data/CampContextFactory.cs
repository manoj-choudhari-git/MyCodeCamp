using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyCodeCamp.Data
{
    public class CampContextFactory : IDesignTimeDbContextFactory<CampContext>
    {
        public CampContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<CampContext>();

            var connectionString = configuration.GetConnectionString("SqlConnectionString");

            dbContextBuilder.UseSqlServer(connectionString);

            return new CampContext(dbContextBuilder.Options);
        }
    }
}
