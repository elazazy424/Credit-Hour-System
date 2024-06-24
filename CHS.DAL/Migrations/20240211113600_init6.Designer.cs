﻿// <auto-generated />
using CHS.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CHS.DAL.Migrations
{
    [DbContext(typeof(CreditHoursSystemContext))]
    [Migration("20240211113600_init6")]
    partial class init6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CHS.DAL.Entites.Enroll", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("Enrolls");
                });

            modelBuilder.Entity("CHS.DAL.Entites.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructorId"));

                    b.Property<string>("InstructorEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstructorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstructorPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstructorType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");

                    b.HasDiscriminator<string>("InstructorType").HasValue("Instructor");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CHS.DAL.Entities.Course", b =>
                {
                    b.Property<string>("CourseCode")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Category")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("CreditHours")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Mandatorness")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PrerequisiteCode")
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("CourseCode");

                    b.HasIndex("PrerequisiteCode");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CHS.DAL.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1000000L);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FinishedHours")
                        .HasColumnType("int");

                    b.Property<decimal>("Gpa")
                        .HasColumnType("decimal(3, 2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CHS.DAL.Entities.StudentFinishedCourses", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("FinishedCourses")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StudentId", "FinishedCourses");

                    b.ToTable("StudentFinishedCourses");
                });

            modelBuilder.Entity("CHS.DAL.Entites.Professor", b =>
                {
                    b.HasBaseType("CHS.DAL.Entites.Instructor");

                    b.Property<int>("OfficeHours")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Professor");
                });

            modelBuilder.Entity("CHS.DAL.Entites.TeachingAssistant", b =>
                {
                    b.HasBaseType("CHS.DAL.Entites.Instructor");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("TeachingAssistant");
                });

            modelBuilder.Entity("CHS.DAL.Entites.Enroll", b =>
                {
                    b.HasOne("CHS.DAL.Entities.Course", "Course")
                        .WithMany("Enrolls")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CHS.DAL.Entities.Student", "Student")
                        .WithMany("Enrolls")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("CHS.DAL.Entities.Course", b =>
                {
                    b.HasOne("CHS.DAL.Entities.Course", "PrerequisiteCourse")
                        .WithMany()
                        .HasForeignKey("PrerequisiteCode");

                    b.Navigation("PrerequisiteCourse");
                });

            modelBuilder.Entity("CHS.DAL.Entities.StudentFinishedCourses", b =>
                {
                    b.HasOne("CHS.DAL.Entities.Student", "Student")
                        .WithMany("StudentFinishedCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("CHS.DAL.Entities.Course", b =>
                {
                    b.Navigation("Enrolls");
                });

            modelBuilder.Entity("CHS.DAL.Entities.Student", b =>
                {
                    b.Navigation("Enrolls");

                    b.Navigation("StudentFinishedCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
