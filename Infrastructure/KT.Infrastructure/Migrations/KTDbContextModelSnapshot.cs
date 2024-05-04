﻿// <auto-generated />
using System;
using KT.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KT.Infrastructure.Migrations
{
    [DbContext(typeof(KTDbContext))]
    partial class KTDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("KT")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KT.Domain.CourseAggregate.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ActualEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("CourseStatus")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("ExpectedEndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LearnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("LearnerId");

                    b.ToTable("Courses", "Course");
                });

            modelBuilder.Entity("KT.Domain.LearnerAggregate.Learner", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Forename")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Learners", "Learner");
                });

            modelBuilder.Entity("KT.Domain.LibraryAggregate.Library", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LibraryType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Libraries", "Library");
                });

            modelBuilder.Entity("KT.Domain.SessionAggregate.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CohortId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MeetingLink")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("SessionType")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Sessions", "Session");
                });

            modelBuilder.Entity("KT.Domain.CourseAggregate.Course", b =>
                {
                    b.HasOne("KT.Domain.LearnerAggregate.Learner", null)
                        .WithMany()
                        .HasForeignKey("LearnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("KT.Domain.CourseAggregate.Entities.Module", "Modules", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("AwardingOrganisation")
                                .HasColumnType("int");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasMaxLength(25)
                                .HasColumnType("nvarchar(25)");

                            b1.Property<Guid>("CourseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Criteria")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<int>("Level")
                                .HasColumnType("int");

                            b1.Property<int>("ModuleStatus")
                                .HasColumnType("int");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("Id");

                            b1.HasIndex("CourseId");

                            b1.ToTable("Modules", "Course");

                            b1.WithOwner()
                                .HasForeignKey("CourseId");
                        });

                    b.Navigation("Modules");
                });

            modelBuilder.Entity("KT.Domain.LearnerAggregate.Learner", b =>
                {
                    b.OwnsMany("KT.Domain.LearnerAggregate.Entities.LearningPlan", "LearningPlans", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<Guid>("LearnerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("Id");

                            b1.HasIndex("LearnerId");

                            b1.ToTable("LearningPlans", "Learner");

                            b1.WithOwner()
                                .HasForeignKey("LearnerId");
                        });

                    b.Navigation("LearningPlans");
                });

            modelBuilder.Entity("KT.Domain.LibraryAggregate.Library", b =>
                {
                    b.OwnsMany("KT.Domain.LibraryAggregate.Entities.CourseTemplate", "CourseTemplates", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasMaxLength(25)
                                .HasColumnType("nvarchar(25)");

                            b1.Property<int>("CourseTemplateStatus")
                                .HasColumnType("int");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<int>("Level")
                                .HasColumnType("int");

                            b1.Property<Guid>("LibraryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("Id");

                            b1.HasIndex("LibraryId");

                            b1.ToTable("CourseTemplates", "Library");

                            b1.WithOwner()
                                .HasForeignKey("LibraryId");

                            b1.OwnsOne("KT.Domain.ActivityPlanTemplate", "ActivityPlanTemplate", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("CourseTemplateId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.HasKey("Id");

                                    b2.HasIndex("CourseTemplateId")
                                        .IsUnique();

                                    b2.ToTable("ActivityPlanTemplates", "Library");

                                    b2.WithOwner()
                                        .HasForeignKey("CourseTemplateId");

                                    b2.OwnsMany("KT.Domain.ActivityTemplate", "ActivityTemplates", b3 =>
                                        {
                                            b3.Property<Guid>("Id")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<Guid>("ActivityPlanTemplateId")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<string>("Description")
                                                .IsRequired()
                                                .HasColumnType("nvarchar(max)");

                                            b3.Property<string>("DocumentIds")
                                                .IsRequired()
                                                .HasColumnType("nvarchar(max)");

                                            b3.Property<TimeSpan>("Duration")
                                                .HasColumnType("time");

                                            b3.Property<string>("ModuleTemplateIds")
                                                .IsRequired()
                                                .HasColumnType("nvarchar(max)");

                                            b3.Property<string>("Title")
                                                .IsRequired()
                                                .HasMaxLength(100)
                                                .HasColumnType("nvarchar(100)");

                                            b3.HasKey("Id");

                                            b3.HasIndex("ActivityPlanTemplateId");

                                            b3.ToTable("ActivityTemplates", "Library");

                                            b3.WithOwner()
                                                .HasForeignKey("ActivityPlanTemplateId");
                                        });

                                    b2.Navigation("ActivityTemplates");
                                });

                            b1.OwnsMany("KT.Domain.LibraryAggregate.Entities.ModuleTemplate", "ModuleTemplates", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<DateTime?>("ActualEndDate")
                                        .HasColumnType("datetime2");

                                    b2.Property<string>("Code")
                                        .IsRequired()
                                        .HasMaxLength(25)
                                        .HasColumnType("nvarchar(25)");

                                    b2.Property<Guid>("CourseTemplateId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("CriteriaTemplates")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasMaxLength(500)
                                        .HasColumnType("nvarchar(500)");

                                    b2.Property<DateTime>("ExpectedEndDate")
                                        .HasColumnType("datetime2");

                                    b2.Property<int>("Level")
                                        .HasColumnType("int");

                                    b2.Property<int>("ModuleType")
                                        .HasColumnType("int");

                                    b2.Property<DateTime>("StartDate")
                                        .HasColumnType("datetime2");

                                    b2.Property<string>("Title")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.HasKey("Id");

                                    b2.HasIndex("CourseTemplateId");

                                    b2.ToTable("ModuleTemplates", "Library");

                                    b2.WithOwner()
                                        .HasForeignKey("CourseTemplateId");
                                });

                            b1.OwnsOne("KT.Domain.LibraryAggregate.Entities.SessionPlanTemplate", "SessionPlanTemplate", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("CourseTemplateId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.HasKey("Id");

                                    b2.HasIndex("CourseTemplateId")
                                        .IsUnique();

                                    b2.ToTable("SessionPlanTemplates", "Library");

                                    b2.WithOwner()
                                        .HasForeignKey("CourseTemplateId");

                                    b2.OwnsMany("KT.Domain.LibraryAggregate.Entities.SessionTemplate", "SessionTemplates", b3 =>
                                        {
                                            b3.Property<Guid>("Id")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<Guid?>("CohortId")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<DateTime>("EndTime")
                                                .HasColumnType("datetime2");

                                            b3.Property<string>("Location")
                                                .IsRequired()
                                                .HasMaxLength(100)
                                                .HasColumnType("nvarchar(100)");

                                            b3.Property<string>("MeetingLink")
                                                .IsRequired()
                                                .HasMaxLength(500)
                                                .HasColumnType("nvarchar(500)");

                                            b3.Property<string>("Notes")
                                                .IsRequired()
                                                .HasMaxLength(500)
                                                .HasColumnType("nvarchar(500)");

                                            b3.Property<Guid>("SessionPlanTemplateId")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<int>("SessionType")
                                                .HasColumnType("int");

                                            b3.Property<DateTime>("StartTime")
                                                .HasColumnType("datetime2");

                                            b3.HasKey("Id");

                                            b3.HasIndex("SessionPlanTemplateId");

                                            b3.ToTable("SessionTemplates", "Library");

                                            b3.WithOwner()
                                                .HasForeignKey("SessionPlanTemplateId");
                                        });

                                    b2.Navigation("SessionTemplates");
                                });

                            b1.Navigation("ActivityPlanTemplate")
                                .IsRequired();

                            b1.Navigation("ModuleTemplates");

                            b1.Navigation("SessionPlanTemplate")
                                .IsRequired();
                        });

                    b.Navigation("CourseTemplates");
                });

            modelBuilder.Entity("KT.Domain.SessionAggregate.Session", b =>
                {
                    b.HasOne("KT.Domain.CourseAggregate.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
