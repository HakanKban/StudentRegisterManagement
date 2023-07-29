﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentRegisterManagement.Data;

#nullable disable

namespace StudentRegisterManagement.Data.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("StudentRegisterManagement.Core.Entities.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("StudentRegisterManagement.Core.Entities.Notes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("TEXT");

                    b.Property<short>("Score")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("StudentRegisterManagement.Core.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<short?>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly?>("BirthDay")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short?>("Size")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("StudentRegisterManagement.Core.Entities.StudentLesson", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId", "LessonId");

                    b.HasIndex("LessonId");

                    b.ToTable("StudentLesson");
                });

            modelBuilder.Entity("StudentRegisterManagement.Core.Entities.Notes", b =>
                {
                    b.HasOne("StudentRegisterManagement.Core.Entities.Lesson", "Lesson")
                        .WithMany("Notes")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("StudentRegisterManagement.Core.Entities.StudentLesson", b =>
                {
                    b.HasOne("StudentRegisterManagement.Core.Entities.Lesson", "Lesson")
                        .WithMany("StudentLesson")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentRegisterManagement.Core.Entities.Student", "Student")
                        .WithMany("StudentLessons")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentRegisterManagement.Core.Entities.Lesson", b =>
                {
                    b.Navigation("Notes");

                    b.Navigation("StudentLesson");
                });

            modelBuilder.Entity("StudentRegisterManagement.Core.Entities.Student", b =>
                {
                    b.Navigation("StudentLessons");
                });
#pragma warning restore 612, 618
        }
    }
}
