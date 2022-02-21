using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GymnasieskolaProjektDatabaser.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GymnasieskolaProjektDatabaser.Data
{
    public partial class GymnasieskolaDbContext : DbContext
    {
        public GymnasieskolaDbContext()
        {
        }

        public GymnasieskolaDbContext(DbContextOptions<GymnasieskolaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBefattning> TblBefattningar { get; set; }
        public virtual DbSet<TblElev> TblElever { get; set; }
        public virtual DbSet<TblElevKurs> TblElevKurser { get; set; }
        public virtual DbSet<TblKlass> TblKlasser { get; set; }
        public virtual DbSet<TblKurs> TblKurser { get; set; }
        public virtual DbSet<TblPersonal> TblPersonalen { get; set; }
        public virtual DbSet<TblSkola> TblSkolor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data source = DESKTOP-O8V61A2;Initial Catalog=GymnasieDB;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBefattning>(entity =>
            {
                entity.HasKey(e => e.BefattningId);

                entity.ToTable("tblBefattning");

                entity.Property(e => e.Avdelning).HasMaxLength(50);

                entity.Property(e => e.Befattning).HasMaxLength(50);
            });

            modelBuilder.Entity<TblElev>(entity =>
            {
                entity.HasKey(e => e.ElevId);

                entity.ToTable("tblElev");

                entity.Property(e => e.Efternamn).HasMaxLength(50);

                entity.Property(e => e.Förnamn).HasMaxLength(50);

                entity.Property(e => e.Personnummer).HasMaxLength(50);

                entity.HasOne(d => d.Klass)
                    .WithMany(p => p.TblElev)
                    .HasForeignKey(d => d.KlassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblElev_tblKlass");
            });

            modelBuilder.Entity<TblElevKurs>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblElev_Kurs");

                entity.Property(e => e.Betyg).HasMaxLength(50);

                entity.Property(e => e.BetygSiffra).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DatumBetyg).HasColumnType("date");

                entity.HasOne(d => d.Elev)
                    .WithMany()
                    .HasForeignKey(d => d.ElevId)
                    .HasConstraintName("FK_tblElev_Kurs_tblElev");

                entity.HasOne(d => d.Kurs)
                    .WithMany()
                    .HasForeignKey(d => d.KursId)
                    .HasConstraintName("FK_tblElev_Kurs_tblKurs");
            });

            modelBuilder.Entity<TblKlass>(entity =>
            {
                entity.HasKey(e => e.KlassId);

                entity.ToTable("tblKlass");

                entity.Property(e => e.KlassNamn).HasMaxLength(50);

                entity.HasOne(d => d.Skol)
                    .WithMany(p => p.TblKlass)
                    .HasForeignKey(d => d.SkolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblKlass_tblSkola");
            });

            modelBuilder.Entity<TblKurs>(entity =>
            {
                entity.HasKey(e => e.KursId);

                entity.ToTable("tblKurs");

                entity.Property(e => e.KursNamn).HasMaxLength(50);

                entity.Property(e => e.SlutDatum).HasColumnType("date");

                entity.Property(e => e.StartDatum).HasColumnType("date");

                entity.HasOne(d => d.Lärare)
                    .WithMany(p => p.TblKurs)
                    .HasForeignKey(d => d.LärareId)
                    .HasConstraintName("FK_tblKurs_tblPersonal1");
            });

            modelBuilder.Entity<TblPersonal>(entity =>
            {
                entity.HasKey(e => e.PersonalId);

                entity.ToTable("tblPersonal");

                entity.Property(e => e.AnställningsDatum).HasColumnType("date");

                entity.Property(e => e.Efternamn).HasMaxLength(50);

                entity.Property(e => e.Förnamn).HasMaxLength(50);

                entity.Property(e => e.Månadslön).HasColumnType("money");

                entity.HasOne(d => d.Befattning)
                    .WithMany(p => p.TblPersonal)
                    .HasForeignKey(d => d.BefattningId)
                    .HasConstraintName("FK_tblPersonal_tblBefattning");
            });

            modelBuilder.Entity<TblSkola>(entity =>
            {
                entity.ToTable("tblSkola");

                entity.Property(e => e.SkolNamn).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
