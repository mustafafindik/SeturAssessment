// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SeturAssessment.ReportService.DataAccess.Concrete.EntityFrameworkCore.Contexts;

namespace SeturAssessment.ReportService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210315191321_PostreSqlInitalForReportService")]
    partial class PostreSqlInitalForReportService
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SeturAssessment.ReportService.Entities.Concrete.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ReportBody")
                        .HasColumnType("text");

                    b.Property<int>("ReportStatusId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("RequestDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ReportStatusId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("SeturAssessment.ReportService.Entities.Concrete.ReportStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("StatusName")
                        .HasColumnType("text");

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

            modelBuilder.Entity("SeturAssessment.ReportService.Entities.Concrete.Report", b =>
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
