using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace IO.Swagger.Models
{
    /// <summary>
    /// Database Context used by the application
    /// </summary>
    public class DbTestContext : DbContext
    {

        /// <summary>
        /// Database Connection String
        /// </summary>
        //public static readonly string ConnectionString = "Host = 127.0.0.1; Username = test; Password = test161107; Database = test";

        /// <summary>
        /// Database Context Constructor
        /// </summary>
        /// <param name="options">Options for the database context</param>
        public DbTestContext(DbContextOptions<DbTestContext> options)
                : base(options)
            {
           

        }

        /// <summary>
        /// Used to get the list of vehicles
        /// </summary>
        public DbSet<Vehicle> Vehicles { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasPostgresExtension("hstore");
        //}


    }
}
