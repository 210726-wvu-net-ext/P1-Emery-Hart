﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RestaurantReviewer.DataAccess.Entities
{
    public partial class PojectzeroContext : DbContext
    {
        public PojectzeroContext()
        {
        }

        public PojectzeroContext(DbContextOptions<PojectzeroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Resturant> Resturants { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Style> Styles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Resturant>(entity =>
            {
                entity.Property(e => e.ResturantId).HasColumnName("ResturantID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.StyleNavigation)
                    .WithMany(p => p.Resturants)
                    .HasForeignKey(d => d.Style)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Resturant__Style__00200768");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.ResturantId).HasColumnName("ResturantID");

                entity.Property(e => e.Thoughts)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Resturant)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ResturantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reviews__Restura__03F0984C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reviews__UserID__02FC7413");
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.ToTable("Style");

                entity.Property(e => e.StyleId).HasColumnName("StyleID");

                entity.Property(e => e.Style1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Style");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AccessLvl).HasColumnName("AccessLVL");

                entity.Property(e => e.Uname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UName");

                entity.Property(e => e.Upass)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UPass");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
