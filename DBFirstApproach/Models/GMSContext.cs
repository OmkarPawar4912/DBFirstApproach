using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBFirstApproach.Models
{
    public partial class GMSContext : DbContext
    {
        public GMSContext()
        {
        }

        public GMSContext(DbContextOptions<GMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MstTrainner> MstTrainner { get; set; }
        public virtual DbSet<MstUser> MstUser { get; set; }
        public virtual DbSet<TblPlan> TblPlan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MstTrainner>(entity =>
            {
                entity.ToTable("Mst_Trainner");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.TrainnerName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(500);
            });

            modelBuilder.Entity<MstUser>(entity =>
            {
                entity.ToTable("Mst_User");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.Role).HasDefaultValueSql("((2))");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(500);

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.MstUser)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK__Mst_User__PlanId__29572725");

                entity.HasOne(d => d.Trainner)
                    .WithMany(p => p.MstUser)
                    .HasForeignKey(d => d.TrainnerId)
                    .HasConstraintName("FK__Mst_User__Trainn__286302EC");
            });

            modelBuilder.Entity<TblPlan>(entity =>
            {
                entity.ToTable("tbl_Plan");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
