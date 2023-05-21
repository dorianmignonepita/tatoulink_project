using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tatoulink.Dbo;

namespace tatoulink.DataAccess.EfModels;

public partial class DbContext : IdentityDbContext
{
    public DbContext()
    {
    }

    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<JobOffer> JobOffers { get; set; }

    public virtual DbSet<JobOfferUser> JobOfferUsers { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<JobOffer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__job_offe__3213E83F06F62932");

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
        });

        modelBuilder.Entity<JobOfferUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__job_offe__3213E83FD79676E2");

            entity.ToTable("job_offer_user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.JobOfferId).HasColumnName("job_offer_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.JobOffer).WithMany(p => p.JobOfferUsers)
                .HasForeignKey(d => d.JobOfferId)
                .HasConstraintName("FK__job_offer__job_o__2F10007B");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__notifica__3213E83F3FB80001");

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
                .HasConstraintName("FK__notificat__job_o__2D27B809");
        });

        modelBuilder.Entity<AspNetUsers>(entity =>
        {
            entity.Property(e => e.UserName).HasColumnName("UserName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
