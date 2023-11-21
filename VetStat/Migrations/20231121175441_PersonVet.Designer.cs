﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VetStat.Data;

#nullable disable

namespace VetStat.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231121175441_PersonVet")]
    partial class PersonVet
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VetStat.Models.Barber", b =>
                {
                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.Property<byte[]>("Certification")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Barber");
                });

            modelBuilder.Entity("VetStat.Models.Customer", b =>
                {
                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.Property<float?>("MembershipLoyalty")
                        .HasColumnType("real");

                    b.Property<DateTime>("ProfileCreationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("VetStat.Models.Nurse", b =>
                {
                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Informations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qualifications")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nurse");
                });

            modelBuilder.Entity("VetStat.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("VetStat.Models.Vet", b =>
                {
                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialSkill")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vet");
                });

            modelBuilder.Entity("VetStat.Models.Barber", b =>
                {
                    b.HasOne("VetStat.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("Id");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("VetStat.Models.Customer", b =>
                {
                    b.HasOne("VetStat.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("Id");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("VetStat.Models.Nurse", b =>
                {
                    b.HasOne("VetStat.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("Id");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("VetStat.Models.Vet", b =>
                {
                    b.HasOne("VetStat.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("Id");

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
