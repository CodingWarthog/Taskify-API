using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HakatonApi.Models
{
    public partial class HackathonWAWContext : DbContext
    {
        public HackathonWAWContext()
        {
        }

        public HackathonWAWContext(DbContextOptions<HackathonWAWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GlobalTag> GlobalTag { get; set; }
        public virtual DbSet<GlobalTask> GlobalTask { get; set; }
        public virtual DbSet<GlobalTaskTag> GlobalTaskTag { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationTag> LocationTag { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<TaskTag> TaskTag { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WaitingTask> WaitingTask { get; set; }
        public virtual DbSet<WaitingTaskLocation> WaitingTaskLocation { get; set; }
        public virtual DbSet<WaitingTaskTag> WaitingTaskTag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:hackathondbserverv1.database.windows.net,1433;Initial Catalog=HackathonWAW;Persist Security Info=False;User ID=HackathonAdmin;Password=!@#Hackathon123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<GlobalTag>(entity =>
            {
                entity.HasKey(e => e.IdGlobalTag)
                    .HasName("PK_GLOBALTAG");

                entity.Property(e => e.GlobalTagName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GlobalTask>(entity =>
            {
                entity.HasKey(e => e.IdGlobalTask)
                    .HasName("PK_GLOBALTASK");

                entity.Property(e => e.GlobalTaskDate).HasColumnType("datetime");

                entity.Property(e => e.GlobalTaskDescription).HasColumnType("text");

                entity.Property(e => e.GlobalTaskName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Longtitude)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GlobalTaskTag>(entity =>
            {
                entity.HasKey(e => e.IdGlobalTaskGlobalTag)
                    .HasName("PK_GLOBALTASKTAG");

                entity.HasOne(d => d.GlobalTag)
                    .WithMany(p => p.GlobalTaskTag)
                    .HasForeignKey(d => d.GlobalTagId)
                    .HasConstraintName("FK_GLOBALTA_REFERENCE_GLOBALTA");

                entity.HasOne(d => d.GlobalTask)
                    .WithMany(p => p.GlobalTaskTag)
                    .HasForeignKey(d => d.GlobalTaskId)
                    .HasConstraintName("FK_GLOBALTA_REFERENCE_GLOBALTA2");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.IdLocation)
                    .HasName("PK_LOCATION");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Longtitude)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LocationTag>(entity =>
            {
                entity.HasKey(e => e.IdLocationTag)
                    .HasName("PK_LOCATIONTAG");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationTag)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_LOCATION_REFERENCE_LOCATION");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.LocationTag)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_LOCATION_REFERENCE_TAG");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.IdTag)
                    .HasName("PK_TAG");

                entity.Property(e => e.TagName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TaskTag>(entity =>
            {
                entity.HasKey(e => e.IdTaskTag)
                    .HasName("PK_TASKTAG");

                entity.Property(e => e.TagName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK_USER");

                entity.Property(e => e.PasswordHash).HasMaxLength(512);

                entity.Property(e => e.PasswordSalt).HasMaxLength(512);

                entity.Property(e => e.UserType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WaitingTask>(entity =>
            {
                entity.HasKey(e => e.IdWaitingTask)
                    .HasName("PK_WAITINGTASK");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateDone).HasColumnType("datetime");

                entity.Property(e => e.DateEnd).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Target).HasColumnType("text");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WaitingTask)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_WAITINGT_REFERENCE_USER");
            });

            modelBuilder.Entity<WaitingTaskLocation>(entity =>
            {
                entity.HasKey(e => e.IdWaitingTaskLocation)
                    .HasName("PK_WAITINGTASKLOCATION");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.WaitingTaskLocation)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_WAITINGT_REFERENCE_LOCATION");

                entity.HasOne(d => d.WaitingTask)
                    .WithMany(p => p.WaitingTaskLocation)
                    .HasForeignKey(d => d.WaitingTaskId)
                    .HasConstraintName("FK_WAITINGT_REFERENCE_WAITINGT");
            });

            modelBuilder.Entity<WaitingTaskTag>(entity =>
            {
                entity.HasKey(e => e.IdWaitingTaskTag)
                    .HasName("PK_WAITINGTASKTAG");

                entity.HasOne(d => d.TaskTag)
                    .WithMany(p => p.WaitingTaskTag)
                    .HasForeignKey(d => d.TaskTagId)
                    .HasConstraintName("FK_WAITINGT_REFERENCE_TASKTAG");

                entity.HasOne(d => d.WaitingTask)
                    .WithMany(p => p.WaitingTaskTag)
                    .HasForeignKey(d => d.WaitingTaskId)
                    .HasConstraintName("FK_SEARCHIN_REFERENCE_SEARCHIN2");
            });
        }
    }
}
