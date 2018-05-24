using System;
using Microsoft.EntityFrameworkCore;
using RightOnBoard.JwtAuthTokenServer.Service.Models.Entities;
using RightOnBoard.Survey.Data.Models;

namespace RightOnBoard.Survey.Data.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Drivers> Driver { get; set; }
        public virtual DbSet<DriverQuestionGroups> DriverQuestionGroup { get; set; }
        public virtual DbSet<QuestionGroups> QuestionGroup { get; set; }
        public virtual DbSet<QuestionOptions> QuestionOptions { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<QuestionTypes> QuestionType { get; set; }
        public virtual DbSet<SurveyInfo> SurveyInfo { get; set; }
        public virtual DbSet<SurveyIteration> SurveyIteration { get; set; }
        public virtual DbSet<QuestionResponses> QuestionResponses { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<SurveyCompany> SurveyCompany { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }

        public virtual DbSet<RegistrationOptions> DeptNames { get; set; }
        public virtual DbSet<RegistrationOptionValues> DeptValues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                //options.UseSqlServer(@"Server=DESKTOP-5E96MVL;Initial Catalog=RightOnBoard;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                options.UseSqlServer(@"Data Source=insyphersql1;Initial Catalog=RightOnBoard;Persist Security Info=True;Integrated Security=false;User ID=rightonboard;Password=rightonboard22;Trusted_Connection=false;MultipleActiveResultSets=true");
            } //p_$@,83L6$z~23mW
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("AspNetUsers");

            //builder.Entity<Questions>().HasKey(p => new {p.SurveyId, p.Id});

            //builder.Entity<Questions>(entity =>
            //{
            //    entity.HasOne(s => s.SurveyInfo)
            //        .WithMany(q => q.Questions)
            //        .HasForeignKey(s => s.SurveyId);
            //});
        }

        protected void OnModelCreating1(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Answers>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.AnswerText)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.AnswerYn).HasColumnName("AnswerYN");

            //    entity.Property(e => e.QuestionOptionId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.Property(e => e.UnitOfMeasureId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.Property(e => e.UserId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.HasOne(d => d.QuestionOption)
            //        .WithMany(p => p.Answers)
            //        .HasForeignKey(d => d.QuestionOptionId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Answers_QuestionOptions");

                //entity.HasOne(d => d.User)
                //    .WithMany(p => p.Answers)
                //    .HasForeignKey(d => d.UserId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Answers_AspNetUsers");
            //});

            //modelBuilder.Entity<Company>(entity =>
            //{
            //    entity.HasIndex(e => e.CompanyName)
            //        .HasName("questionnaire_name_UNIQUE");

            //    entity.Property(e => e.CompanyId).ValueGeneratedNever();

            //    entity.Property(e => e.CompanyName)
            //        .IsRequired()
            //        .HasMaxLength(200);
            //});

            //modelBuilder.Entity<Driver>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.DriverName).HasMaxLength(1000);
            //});

            //modelBuilder.Entity<DriverQuestionGroup>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.DriverId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.Property(e => e.QuestionGroupId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.Property(e => e.QuestionId)
            //        .IsRequired()
            //        .HasMaxLength(450);
            //});

            //modelBuilder.Entity<QuestionGroup>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.QuestionGroupDescription).HasMaxLength(1000);

            //    entity.Property(e => e.QuestionGroupName).HasMaxLength(100);
            //});

            //modelBuilder.Entity<QuestionOptions>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.OptionChoiceId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.Property(e => e.QuestionId)
            //        .IsRequired()
            //        .HasMaxLength(450);
            //});

            //modelBuilder.Entity<Questions>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.QuestionName).HasMaxLength(255);

            //    entity.Property(e => e.QuestionNumber).HasMaxLength(50);

            //    entity.Property(e => e.QuestionText).HasMaxLength(500);

            //    entity.Property(e => e.QuestionTypeId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.Property(e => e.SurveyId)
            //        .IsRequired()
            //        .HasMaxLength(450);
            //});

            //modelBuilder.Entity<QuestionType>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.QuestionTypeName).HasMaxLength(80);
            //});

            //modelBuilder.Entity<RefreshTokens>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasMaxLength(128)
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.ClientId)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.ExpiresUtc).HasColumnType("datetime");

            //    entity.Property(e => e.IssueUtc).HasColumnType("datetime");

            //    entity.Property(e => e.ProtectedTicket).IsRequired();

            //    entity.Property(e => e.Subject)
            //        .IsRequired()
            //        .HasMaxLength(100);
            //});

            //modelBuilder.Entity<SurveyInfo>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.Description).HasMaxLength(500);

            //    entity.Property(e => e.EndDate).HasColumnType("datetime");

            //    entity.Property(e => e.ExitMessage).HasMaxLength(500);

            //    entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

            //    entity.Property(e => e.Name).HasMaxLength(250);

            //    entity.Property(e => e.PublicationDate).HasColumnType("datetime");

            //    entity.Property(e => e.StartDate).HasColumnType("datetime");

            //    entity.Property(e => e.WelcomeMessage).HasMaxLength(500);
            //});
        }
    }
}
