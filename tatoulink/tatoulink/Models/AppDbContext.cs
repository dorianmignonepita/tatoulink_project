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

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JobOffer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__job_offe__3213E83F6BA3E895");

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
                .HasConstraintName("FK__job_offer__creat__49C3F6B7");
        });

        modelBuilder.Entity<JobOfferUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("job_offer_user");

            entity.Property(e => e.JobOfferId).HasColumnName("job_offer_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.JobOffer).WithMany()
                .HasForeignKey(d => d.JobOfferId)
                .HasConstraintName("FK__job_offer__job_o__4AB81AF0");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__job_offer__user___4BAC3F29");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83FE02D70B4");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "UQ__user__AB6E6164F2FD1D51").IsUnique();

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
