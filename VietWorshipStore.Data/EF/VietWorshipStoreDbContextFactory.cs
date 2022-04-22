using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VietWorshipStore.Data.EF
{
    public class VietWorshipStoreDbContextFactory : IDesignTimeDbContextFactory<VietWorshipStoreDbContext>
    {
        public VietWorshipStoreDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("VietWorshipStoreDb");

            var optionsBuilder = new DbContextOptionsBuilder<VietWorshipStoreDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new VietWorshipStoreDbContext(optionsBuilder.Options);
        }
    }
}
