using Microsoft.EntityFrameworkCore;

namespace RightOnBoard.Survey.Data.Models
{
    public class ApplicationDbContextOld : Microsoft.EntityFrameworkCore.DbContext
    {
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Drivers> Driver { get; set; }
        public virtual DbSet<DriverQuestionGroups> DriverQuestionGroup { get; set; }
        public virtual DbSet<QuestionGroups> QuestionGroup { get; set; }
        public virtual DbSet<QuestionOptions> QuestionOptions { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<QuestionTypes> QuestionType { get; set; }
        public virtual DbSet<SurveyInfo> Survey { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=insyphersql1;Initial Catalog=RightOnBoard;Persist Security Info=True;User ID=rightonboard;Password=rightonboard22;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AnswerText)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AnswerYn).HasColumnName("AnswerYN");

                entity.Property(e => e.QuestionOptionId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.UnitOfMeasureId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.QuestionOption)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionOptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answers_QuestionOptions");

                //entity.HasOne(d => d.User)
                //    .WithMany(p => p.Answers)
                //    .HasForeignKey(d => d.UserId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Answers_AspNetUsers");
            });


            //modelBuilder.Entity<Driver>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.DriverName).HasMaxLength(1000);
            //});

            modelBuilder.Entity<DriverQuestionGroups>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DriverId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.QuestionGroupId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.QuestionId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<QuestionGroups>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.QuestionGroupDescription).HasMaxLength(1000);

                entity.Property(e => e.QuestionGroupName).HasMaxLength(100);
            });

            modelBuilder.Entity<QuestionOptions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.OptionChoiceId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.QuestionId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.QuestionName).HasMaxLength(255);

                entity.Property(e => e.QuestionNumber).HasMaxLength(50);

                entity.Property(e => e.QuestionText).HasMaxLength(500);

                entity.Property(e => e.QuestionTypeId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.SurveyId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<QuestionTypes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.QuestionTypeName).HasMaxLength(80);
            });           

            modelBuilder.Entity<SurveyInfo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ExitMessage).HasMaxLength(500);

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.PublicationDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.WelcomeMessage).HasMaxLength(500);
            });
        }
    }
}
