using IO.Swagger.Controllers;
using IO.Swagger.Models;
using System;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Swagger.Model;
using Swashbuckle.SwaggerGen.Annotations;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Moq;
using test;

namespace Tests
{
    public class Tests
    {
        private readonly VehicleApiController _vehicleApiController;
        public Tests()
        {
            // first we need a database context.


            //var connectionString = Configuration["DbContextSettings:ConnectionString"];
            //var connectionString = "Host = 127.0.0.1; Username = test; Password = test161107; Database = test";
            //DbContextOptions<DbTestContext> options = new DbContextOptions<DbTestContext>(opts => opts.UseNpgsql(connectionString));
            
            var dbTestContext = new Mock <DbTestContext>();
            Vehicle fakeVehicle = new Vehicle(1, "Test Name", "Test Description");

            Mock<DbSet<Vehicle>> mockVehicles = MockDbSet.Create(fakeVehicle);

            dbTestContext.Setup(x => x.Vehicles).Returns(mockVehicles.Object);

            _vehicleApiController = new VehicleApiController(dbTestContext.Object);
        }
        [Fact]
        public void Test1() 
        {
            var result = _vehicleApiController.VehiclesGet();

            System.Console.Out.WriteLine ("Test");

            Assert.True(true);
        }
    }
}
