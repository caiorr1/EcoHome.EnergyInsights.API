using Microsoft.EntityFrameworkCore;
using EcoHome.EnergyInsights.Domain.Entities;

namespace EcoHome.EnergyInsights.Infrastructure.Data
{
    public class EnergyInsightsContext : DbContext
    {
        public EnergyInsightsContext(DbContextOptions<EnergyInsightsContext> options)
            : base(options) { }

        // DbSet para as entidades utilizadas no projeto
        public DbSet<InsightEntity> Insights { get; set; }
        public DbSet<UserConsumptionGoalEntity> UserConsumptionGoals { get; set; }
        public DbSet<NotificationLogEntity> NotificationLogs { get; set; }
        public DbSet<ReportEntity> Reports { get; set; }
        public DbSet<EnergySavingTipEntity> EnergySavingTips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade EnergySavingTipEntity
            modelBuilder.Entity<EnergySavingTipEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.IsActive)
                      .IsRequired()
                      .HasConversion<int>(); // Mapeia BOOLEAN para NUMBER(1)
            });

            // Configuração da entidade InsightEntity
            modelBuilder.Entity<InsightEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.ExternalUserId).IsRequired().HasMaxLength(50);
                entity.Property(e => e.IsRead)
                      .IsRequired()
                      .HasConversion<int>(); // Mapeia BOOLEAN para NUMBER(1)
            });

            // Configuração da entidade UserConsumptionGoalEntity
            modelBuilder.Entity<UserConsumptionGoalEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Category).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Goal).IsRequired();
                entity.Property(e => e.ValidUntil).IsRequired();
                entity.Property(e => e.ExternalUserId).IsRequired().HasMaxLength(50);
            });

            // Configuração da entidade NotificationLogEntity
            modelBuilder.Entity<NotificationLogEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.NotificationType).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Message).IsRequired().HasMaxLength(500);
                entity.Property(e => e.SentAt).IsRequired();
                entity.Property(e => e.ExternalUserId).IsRequired().HasMaxLength(50);
                entity.Property(e => e.IsRead)
                      .IsRequired()
                      .HasConversion<int>(); // Mapeia BOOLEAN para NUMBER(1)
            });

            // Configuração da entidade ReportEntity
            modelBuilder.Entity<ReportEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ReportType).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Data).IsRequired();
                entity.Property(e => e.GeneratedAt).IsRequired();
                entity.Property(e => e.ExternalUserId).IsRequired().HasMaxLength(50);
            });
        }
    }
}
