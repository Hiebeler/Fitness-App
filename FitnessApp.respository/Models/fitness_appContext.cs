using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FitnessApp.respository.Models
{
    public partial class fitness_appContext : DbContext
    {
        public fitness_appContext()
        {
        }

        public fitness_appContext(DbContextOptions<fitness_appContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompletedTraining> CompletedTrainings { get; set; } = null!;
        public virtual DbSet<Exercise> Exercises { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Workout> Workouts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("name=fitnessDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<CompletedTraining>(entity =>
            {
                entity.ToTable("completed_trainings");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.UserUid).HasColumnName("user_uid");

                entity.Property(e => e.WorkoutId).HasColumnName("workout_id");

                entity.HasOne(d => d.UserU)
                    .WithMany(p => p.CompletedTrainings)
                    .HasForeignKey(d => d.UserUid)
                    .HasConstraintName("completed_trainings_user_uid_fkey");

                entity.HasOne(d => d.Workout)
                    .WithMany(p => p.CompletedTrainings)
                    .HasForeignKey(d => d.WorkoutId)
                    .HasConstraintName("completed_trainings_workout_id_fkey");
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.ToTable("exercise");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ExerciseName)
                    .HasMaxLength(64)
                    .HasColumnName("exercise_name");

                entity.Property(e => e.Explanation)
                    .HasColumnType("character varying")
                    .HasColumnName("explanation");

                entity.Property(e => e.ImageLink)
                    .HasColumnType("character varying")
                    .HasColumnName("image_link");

                entity.Property(e => e.WorkoutId).HasColumnName("workout_id");

                entity.HasOne(d => d.Workout)
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.WorkoutId)
                    .HasConstraintName("exercise_workout_id_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("user_pkey");

                entity.ToTable("user");

                entity.HasIndex(e => e.Email, "user_email_key")
                    .IsUnique();

                entity.Property(e => e.Uid)
                    .ValueGeneratedNever()
                    .HasColumnName("uid");

                entity.Property(e => e.Email)
                    .HasMaxLength(320)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.ToTable("workout");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.ImageLink)
                    .HasColumnType("character varying")
                    .HasColumnName("image_link");

                entity.Property(e => e.UserUid).HasColumnName("user_uid");

                entity.Property(e => e.WorkoutName)
                    .HasMaxLength(64)
                    .HasColumnName("workout_name");

                entity.HasOne(d => d.UserU)
                    .WithMany(p => p.Workouts)
                    .HasForeignKey(d => d.UserUid)
                    .HasConstraintName("workout_user_uid_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
