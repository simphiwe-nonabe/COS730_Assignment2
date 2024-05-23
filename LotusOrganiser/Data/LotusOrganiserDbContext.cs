using Microsoft.EntityFrameworkCore;
using LotusOrganiser.Data.Constants;
using LotusOrganiser.Entities;

namespace LotusOrganiser.Data
{
    public class LotusOrganiserDbContext : DbContext
    {
        public LotusOrganiserDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Level> Levels { get; set; }

        public DbSet<Certification> Certifications { get; set; }

        public DbSet<UserCertification> UserCertifications { get; set; }

        public DbSet<TrainingStatus> TrainingStatuses { get; set; }

        public DbSet<TrainingHR> TrainingHRs { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<MotivationForm> MotivationForms { get; set; }

        public DbSet<TrainingProvider> TrainingProviders { get; set; }

        public DbSet<CertificationType> CertificationTypes { get; set; }

        public DbSet<TrainingReason> TrainingReasons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Inserting constants of training status into the training status table.
            TrainingStatus[] statusToInsert =
            {
                new TrainingStatus(
                    TrainingStatusConstants.PendingApproval,
                    nameof(TrainingStatusConstants.PendingApproval)),
                new TrainingStatus(
                    TrainingStatusConstants.InProgress,
                    nameof(TrainingStatusConstants.InProgress)),
                new TrainingStatus(
                    TrainingStatusConstants.Completed,
                    nameof(TrainingStatusConstants.Completed)),
                new TrainingStatus(
                    TrainingStatusConstants.Overdue,
                    nameof(TrainingStatusConstants.Overdue))
            };
            modelBuilder.Entity<TrainingStatus>().HasData(statusToInsert);

            // Inserting constants of training status into the training status table.
            Level[] levelsToInsert =
            {
                new Level(
                    LevelConstants.Graduate,
                    nameof(LevelConstants.Graduate)),
                new Level(
                    LevelConstants.Junior,
                    nameof(LevelConstants.Junior)),
                new Level(
                    LevelConstants.Intermediate,
                    nameof(LevelConstants.Intermediate)),
                new Level(
                    LevelConstants.Senior,
                    nameof(LevelConstants.Senior))
            };
            modelBuilder.Entity<Level>().HasData(levelsToInsert);
        }
    }
}