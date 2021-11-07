using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SurveySystem.ORM.DBModels
{
    public partial class ContextModel : DbContext
    {
        public ContextModel()
            : base("name=DefaultConnectionString")
        {
        }

        public virtual DbSet<AcInfo> AcInfo { get; set; }
        public virtual DbSet<FAQ> FAQ { get; set; }
        public virtual DbSet<Questionnaire> Questionnaire { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<QuestionnaireDetails> QuestionnaireDetails { get; set; }
        public virtual DbSet<Survey> Survey { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcInfo>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<AcInfo>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Questionnaire>()
                .HasMany(e => e.QuestionnaireDetails)
                .WithRequired(e => e.Questionnaire)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Questionnaire>()
                .HasMany(e => e.Survey)
                .WithRequired(e => e.Questionnaire)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.MobilePhone)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Age)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .HasMany(e => e.Survey)
                .WithRequired(e => e.UserInfo)
                .WillCascadeOnDelete(false);
        }
    }
}
