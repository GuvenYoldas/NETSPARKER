using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace NETSPARKER.Data
{
    /// <summary>
    /// The NETSPARKERDbContextFactory
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory{NETSPARKER.Data.NETSPARKERDbContext}" />
    public class NetsparkerDbContextFactory : IDesignTimeDbContextFactory<NetsparkerDbContext>
    {
        /// <summary>
        /// Creates a new instance of a derived context.
        /// </summary>
        /// <param name="args">Arguments provided by the design-time service.</param>
        /// <returns>
        /// An instance of <typeparamref name="TContext" />.
        /// </returns>
        public NetsparkerDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<NetsparkerDbContext>();
            var connectionString = configuration.GetConnectionString("NETSPARKERDbConnection");

            builder.UseSqlServer(connectionString);
            return new NetsparkerDbContext(builder.Options);
        }
    }
}