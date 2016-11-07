using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IO.Swagger.Models;

namespace IO.Swagger.Migrations
{
    [DbContext(typeof(DbTestContext))]
    partial class DbTestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("IO.Swagger.Models.Vehicle", b =>
                {
                    b.Property<int?>("VehicleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("DisplayName");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");
                });
        }
    }
}
