﻿// <auto-generated />
using Calculatorwebapi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Calculatorwebapi.Migrations
{
    [DbContext(typeof(Dbcontextclass))]
    [Migration("20240221064200_intialmigration")]
    partial class intialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Calculatorwebapi.model.Calculatormodel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MathOption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Num1")
                        .HasColumnType("float");

                    b.Property<double>("Num2")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("calculatormodel");
                });
#pragma warning restore 612, 618
        }
    }
}