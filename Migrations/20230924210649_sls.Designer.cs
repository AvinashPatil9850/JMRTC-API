﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using msrtc_api.Data;

#nullable disable

namespace msrtc_api.Migrations
{
    [DbContext(typeof(MsrtcContext))]
    [Migration("20230924210649_sls")]
    partial class sls
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("msrtc_api.Entities.BusStopsModel", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ID"));

                    b.Property<int?>("BusID")
                        .HasColumnType("int");

                    b.Property<int?>("BussessModelBusID")
                        .HasColumnType("int");

                    b.Property<string>("Stop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BussessModelBusID");

                    b.ToTable("BusStopsModel");
                });

            modelBuilder.Entity("msrtc_api.Entities.BussessModel", b =>
                {
                    b.Property<int>("BusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusID"));

                    b.Property<string>("BusDepo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusRoute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Via")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BusID");

                    b.ToTable("Bussess");
                });

            modelBuilder.Entity("msrtc_api.Entities.DestinationArr", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DepoID")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DepoID");

                    b.ToTable("DestinationArr");
                });

            modelBuilder.Entity("msrtc_api.Entities.DestinationModal", b =>
                {
                    b.Property<int>("DepoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepoID"));

                    b.Property<string>("BusDepo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepoID");

                    b.ToTable("DestinationModal");
                });

            modelBuilder.Entity("msrtc_api.Entities.StopDetail", b =>
                {
                    b.Property<int?>("StopID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("StopID"));

                    b.Property<int?>("ID")
                        .HasColumnType("int");

                    b.Property<string>("StopName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StopID");

                    b.HasIndex("ID");

                    b.ToTable("StopDetail");
                });

            modelBuilder.Entity("msrtc_api.Entities.StopsListModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BusDepo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("StopsListModel");
                });

            modelBuilder.Entity("msrtc_api.Entities.WeekDaysModel", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ID"));

                    b.Property<string>("Abbr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BusID")
                        .HasColumnType("int");

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BusID");

                    b.ToTable("WeekDaysModel");
                });

            modelBuilder.Entity("msrtc_api.Entities.BusStopsModel", b =>
                {
                    b.HasOne("msrtc_api.Entities.BussessModel", null)
                        .WithMany("Stops")
                        .HasForeignKey("BussessModelBusID");
                });

            modelBuilder.Entity("msrtc_api.Entities.DestinationArr", b =>
                {
                    b.HasOne("msrtc_api.Entities.DestinationModal", "DestinationModal")
                        .WithMany("DestinationArr")
                        .HasForeignKey("DepoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DestinationModal");
                });

            modelBuilder.Entity("msrtc_api.Entities.StopDetail", b =>
                {
                    b.HasOne("msrtc_api.Entities.StopsListModel", "StopsListModel")
                        .WithMany("StopsList")
                        .HasForeignKey("ID");

                    b.Navigation("StopsListModel");
                });

            modelBuilder.Entity("msrtc_api.Entities.WeekDaysModel", b =>
                {
                    b.HasOne("msrtc_api.Entities.BussessModel", "BussessModel")
                        .WithMany()
                        .HasForeignKey("BusID");

                    b.Navigation("BussessModel");
                });

            modelBuilder.Entity("msrtc_api.Entities.BussessModel", b =>
                {
                    b.Navigation("Stops");
                });

            modelBuilder.Entity("msrtc_api.Entities.DestinationModal", b =>
                {
                    b.Navigation("DestinationArr");
                });

            modelBuilder.Entity("msrtc_api.Entities.StopsListModel", b =>
                {
                    b.Navigation("StopsList");
                });
#pragma warning restore 612, 618
        }
    }
}
