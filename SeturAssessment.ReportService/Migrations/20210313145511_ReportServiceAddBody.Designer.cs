﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeturAssessment.ReportService.DataAccess.Concrete.EntityFrameworkCore.Contexts;

namespace SeturAssessment.ReportService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210313145511_ReportServiceAddBody")]
    partial class ReportServiceAddBody
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SeturAssessment.ReportService.Entities.Concrete.ReportStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ReportStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusName = "Hazırlanıyor"
                        },
                        new
                        {
                            Id = 2,
                            StatusName = "Tamamlandı"
                        });
                });

            modelBuilder.Entity("SeturAssessment.ReportService.Entities.Concrete.Reports", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReportBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReportStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RequestDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ReportStatusId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("SeturAssessment.ReportService.Entities.Concrete.Reports", b =>
                {
                    b.HasOne("SeturAssessment.ReportService.Entities.Concrete.ReportStatus", "ReportStatus")
                        .WithMany()
                        .HasForeignKey("ReportStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
