﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeturAssessment.ContactService.DataAccess.Concrete.EntityFrameworkCore.Contexts;

namespace SeturAssessment.ContactService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SeturAssessment.ContactService.Entities.Concrete.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Firm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("SeturAssessment.ContactService.Entities.Concrete.ContactLocation", b =>
                {
                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LocationId", "ContactId");

                    b.HasIndex("ContactId");

                    b.ToTable("ContactLocation");
                });

            modelBuilder.Entity("SeturAssessment.ContactService.Entities.Concrete.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("SeturAssessment.ContactService.Entities.Concrete.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("SeturAssessment.ContactService.Entities.Concrete.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("SeturAssessment.ContactService.Entities.Concrete.ContactLocation", b =>
                {
                    b.HasOne("SeturAssessment.ContactService.Entities.Concrete.Contact", "Contact")
                        .WithMany("ContactLocations")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeturAssessment.ContactService.Entities.Concrete.Location", "Location")
                        .WithMany("ContactLocations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("SeturAssessment.ContactService.Entities.Concrete.Email", b =>
                {
                    b.HasOne("SeturAssessment.ContactService.Entities.Concrete.Contact", "Contact")
                        .WithMany("Emails")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("SeturAssessment.ContactService.Entities.Concrete.Phone", b =>
                {
                    b.HasOne("SeturAssessment.ContactService.Entities.Concrete.Contact", "Contact")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("SeturAssessment.ContactService.Entities.Concrete.Contact", b =>
                {
                    b.Navigation("ContactLocations");

                    b.Navigation("Emails");

                    b.Navigation("PhoneNumbers");
                });

            modelBuilder.Entity("SeturAssessment.ContactService.Entities.Concrete.Location", b =>
                {
                    b.Navigation("ContactLocations");
                });
#pragma warning restore 612, 618
        }
    }
}
