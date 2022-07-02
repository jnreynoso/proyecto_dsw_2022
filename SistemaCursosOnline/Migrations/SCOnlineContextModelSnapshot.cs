﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaCursosOnline.Data;

#nullable disable

namespace SistemaCursosOnline.Migrations
{
    [DbContext(typeof(SCOnlineContext))]
    partial class SCOnlineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SistemaCursosOnline.Models.Course", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photo_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("scheduleId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("scheduleId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            id = 5,
                            description = "Odoo",
                            name = "Python",
                            scheduleId = 1
                        },
                        new
                        {
                            id = 6,
                            description = "Indices, Consultas, DDL",
                            name = "MySql",
                            scheduleId = 2
                        },
                        new
                        {
                            id = 7,
                            description = "Estructuras de datos",
                            name = "Java",
                            scheduleId = 3
                        },
                        new
                        {
                            id = 8,
                            description = "Servicios",
                            name = "ITIL v4",
                            scheduleId = 4
                        });
                });

            modelBuilder.Entity("SistemaCursosOnline.Models.Gender", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Gender");

                    b.HasData(
                        new
                        {
                            id = 9,
                            name = "Masculino"
                        },
                        new
                        {
                            id = 10,
                            name = "Femenino"
                        },
                        new
                        {
                            id = 11,
                            name = "Otro"
                        });
                });

            modelBuilder.Entity("SistemaCursosOnline.Models.Schedule", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("beginning_hour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("finish_hour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("turn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Schedule");

                    b.HasData(
                        new
                        {
                            id = 1,
                            beginning_hour = "8am",
                            duration = "2 horas",
                            finish_hour = "10am",
                            turn = "Lunes - Miércoles - Viernes"
                        },
                        new
                        {
                            id = 2,
                            beginning_hour = "1pm",
                            duration = "2 horas",
                            finish_hour = "3pm",
                            turn = "Lunes - Miércoles - Viernes"
                        },
                        new
                        {
                            id = 3,
                            beginning_hour = "8am",
                            duration = "3 horas",
                            finish_hour = "11am",
                            turn = "Martes - Jueves - Sábado"
                        },
                        new
                        {
                            id = 4,
                            beginning_hour = "4pm",
                            duration = "4 horas",
                            finish_hour = "8pm",
                            turn = "Martes - Jueves - Sábado"
                        });
                });

            modelBuilder.Entity("SistemaCursosOnline.Models.Teacher", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("cv_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("genderId")
                        .HasColumnType("int");

                    b.Property<string>("names")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("genderId");

                    b.ToTable("Teacher");

                    b.HasData(
                        new
                        {
                            id = 12,
                            cv_url = "http://jnreynoso.github.io/CV.pdf",
                            dni = "72494607",
                            email = "jreynoso.mena@gmail.com",
                            genderId = 9,
                            names = "Jean Reynoso",
                            phone = "923359438"
                        },
                        new
                        {
                            id = 13,
                            cv_url = "http://jnreynoso.github.io/CV.pdf",
                            dni = "00494607",
                            email = "pjreynoso.mena@gmail.com",
                            genderId = 9,
                            names = "Pablo Reynoso",
                            phone = "923354545"
                        });
                });

            modelBuilder.Entity("SistemaCursosOnline.Models.TeacherScheduling", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("courseId")
                        .HasColumnType("int");

                    b.Property<int?>("scheduleId")
                        .HasColumnType("int");

                    b.Property<int?>("teacherId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("courseId");

                    b.HasIndex("scheduleId");

                    b.HasIndex("teacherId");

                    b.ToTable("TeacherScheduling");

                    b.HasData(
                        new
                        {
                            id = 14,
                            courseId = 5,
                            scheduleId = 1,
                            teacherId = 12
                        },
                        new
                        {
                            id = 15,
                            courseId = 5,
                            scheduleId = 2,
                            teacherId = 12
                        },
                        new
                        {
                            id = 16,
                            courseId = 6,
                            scheduleId = 1,
                            teacherId = 12
                        },
                        new
                        {
                            id = 17,
                            courseId = 6,
                            scheduleId = 2,
                            teacherId = 12
                        });
                });

            modelBuilder.Entity("SistemaCursosOnline.Models.Course", b =>
                {
                    b.HasOne("SistemaCursosOnline.Models.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("scheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("SistemaCursosOnline.Models.Teacher", b =>
                {
                    b.HasOne("SistemaCursosOnline.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("genderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("SistemaCursosOnline.Models.TeacherScheduling", b =>
                {
                    b.HasOne("SistemaCursosOnline.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("courseId");

                    b.HasOne("SistemaCursosOnline.Models.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("scheduleId");

                    b.HasOne("SistemaCursosOnline.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("teacherId");

                    b.Navigation("Course");

                    b.Navigation("Schedule");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
