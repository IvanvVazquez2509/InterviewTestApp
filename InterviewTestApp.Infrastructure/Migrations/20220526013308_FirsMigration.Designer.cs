﻿// <auto-generated />
using System;
using InterviewTestApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InterviewTestApp.Infrastructure.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220526013308_FirsMigration")]
    partial class FirsMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InterviewTestApp.Domain.Entites.HealthCheck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("message");

                    b.HasKey("Id");

                    b.ToTable("healthCheck", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Message = "OH NO!"
                        },
                        new
                        {
                            Id = 2,
                            Message = "Everything is OK!"
                        });
                });

            modelBuilder.Entity("InterviewTestApp.Domain.Entites.LstWeatherType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("lstWeatherType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Rain"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Snow"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Sun"
                        });
                });

            modelBuilder.Entity("InterviewTestApp.Domain.Entites.TableWeatherForecast", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("description");

                    b.Property<double>("TemperatureCelseus")
                        .HasColumnType("float")
                        .HasColumnName("tempc");

                    b.Property<int>("WeatherTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WeatherTypeId");

                    b.ToTable("weatherForecast", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c2c72824-3313-483b-8648-002ebd14c90e"),
                            Date = new DateTime(2022, 5, 25, 19, 33, 8, 464, DateTimeKind.Local).AddTicks(2054),
                            Description = "Dreary Weather!",
                            TemperatureCelseus = 20.0,
                            WeatherTypeId = 1
                        },
                        new
                        {
                            Id = new Guid("cf25592f-8fa4-4ec4-b0da-cf5c120e8cc4"),
                            Date = new DateTime(2022, 5, 25, 19, 33, 8, 464, DateTimeKind.Local).AddTicks(2105),
                            Description = "Cold Weather!",
                            TemperatureCelseus = 5.0,
                            WeatherTypeId = 2
                        },
                        new
                        {
                            Id = new Guid("3f9cd820-0750-4237-8fb9-263cfebe7c84"),
                            Date = new DateTime(2022, 5, 25, 19, 33, 8, 464, DateTimeKind.Local).AddTicks(2108),
                            Description = "Hot Weather!",
                            TemperatureCelseus = 40.0,
                            WeatherTypeId = 3
                        });
                });

            modelBuilder.Entity("InterviewTestApp.Domain.Entites.TableWeatherForecast", b =>
                {
                    b.HasOne("InterviewTestApp.Domain.Entites.LstWeatherType", "WeatherType")
                        .WithMany("WeatherForecasts")
                        .HasForeignKey("WeatherTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WeatherType");
                });

            modelBuilder.Entity("InterviewTestApp.Domain.Entites.LstWeatherType", b =>
                {
                    b.Navigation("WeatherForecasts");
                });
#pragma warning restore 612, 618
        }
    }
}
