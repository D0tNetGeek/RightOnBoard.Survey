﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RightOnBoard.Survey.Data.DbContext;
using System;

namespace RightOnBoard.Survey.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RightOnBoard.Survey.Data.Models.Answers", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AnswerNumeric");

                    b.Property<string>("AnswerText");

                    b.Property<bool?>("AnswerYn");

                    b.Property<string>("QuestionOptionId");

                    b.Property<string>("UnitOfMeasureId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionOptionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("RightOnBoard.Survey.Data.Models.Company", b =>
                {
                    b.Property<string>("CompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("RightOnBoard.Survey.Data.Models.DriverQuestionGroups", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DriverId");

                    b.Property<string>("QuestionGroupId");

                    b.Property<string>("QuestionId");

                    b.HasKey("Id");

                    b.ToTable("DriverQuestionGroup");
                });

            modelBuilder.Entity("RightOnBoard.Survey.Data.Models.Drivers", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DriverName");

                    b.HasKey("Id");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("RightOnBoard.Survey.Data.Models.QuestionGroups", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("QuestionGroupDescription");

                    b.Property<string>("QuestionGroupName");

                    b.HasKey("Id");

                    b.ToTable("QuestionGroup");
                });

            modelBuilder.Entity("RightOnBoard.Survey.Data.Models.QuestionOptions", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("OptionChoiceId");

                    b.Property<string>("QuestionId");

                    b.HasKey("Id");

                    b.ToTable("QuestionOptions");
                });

            modelBuilder.Entity("RightOnBoard.Survey.Data.Models.Questions", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("QuestionAnswerRequired");

                    b.Property<string>("QuestionName");

                    b.Property<string>("QuestionNumber");

                    b.Property<int?>("QuestionSequence");

                    b.Property<string>("QuestionText");

                    b.Property<string>("QuestionTypeId");

                    b.Property<string>("SurveyId");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("RightOnBoard.Survey.Data.Models.QuestionTypes", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("QuestionTypeHasChoices");

                    b.Property<string>("QuestionTypeName");

                    b.HasKey("Id");

                    b.ToTable("QuestionType");
                });

            modelBuilder.Entity("RightOnBoard.Survey.Data.Models.SurveyInfo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("ExitMessage");

                    b.Property<DateTime?>("ExpirationDate");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("PublicationDate");

                    b.Property<DateTime?>("StartDate");

                    b.Property<string>("WelcomeMessage");

                    b.HasKey("Id");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("RightOnBoard.Survey.Data.Models.Answers", b =>
                {
                    b.HasOne("RightOnBoard.Survey.Data.Models.QuestionOptions", "QuestionOption")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionOptionId");
                });
#pragma warning restore 612, 618
        }
    }
}
