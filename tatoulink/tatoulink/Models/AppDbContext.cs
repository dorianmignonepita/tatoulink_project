using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace tatoulink.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<JobOffer> JobOffers { get; set; }

    public virtual DbSet<JobOfferUser> JobOfferUsers { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JobOffer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__job_offe__3213E83FB39E3FE1");

            entity.ToTable("job_offer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("creation_date");
            entity.Property(e => e.CreatorId).HasColumnName("creator_id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Duration)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("duration");
            entity.Property(e => e.ExpiringDate)
                .HasColumnType("datetime")
                .HasColumnName("expiring_date");
            entity.Property(e => e.OfferName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("offer_name");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Creator).WithMany(p => p.JobOffers)
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__job_offer__creat__5812160E");
        });

        modelBuilder.Entity<JobOfferUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__job_offe__3213E83F524892BE");

            entity.ToTable("job_offer_user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.JobOfferId).HasColumnName("job_offer_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.JobOffer).WithMany(p => p.JobOfferUsers)
                .HasForeignKey(d => d.JobOfferId)
                .HasConstraintName("FK__job_offer__job_o__59063A47");

            entity.HasOne(d => d.User).WithMany(p => p.JobOfferUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__job_offer__user___59FA5E80");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__notifica__3213E83FDC1D1A49");

            entity.ToTable("notification");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.JobOfferUserId).HasColumnName("job_offer_user_id");
            entity.Property(e => e.Message)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("message");
            entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.JobOfferUser).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.JobOfferUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__notificat__job_o__571DF1D5");

            entity.HasOne(d => d.Receiver).WithMany(p => p.NotificationReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__notificat__recei__5629CD9C");

            entity.HasOne(d => d.Sender).WithMany(p => p.NotificationSenders)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__notificat__sende__5535A963");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83F8B3C4F9D");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "UQ__user__AB6E616472E53061").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate)
                .HasColumnType("datetime")
                .HasColumnName("birthdate");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.LastJobs)
                .IsUnicode(false)
                .HasColumnName("last_jobs");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
