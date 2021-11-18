using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PartyFinderData.ModelLayers
{
    public partial class PartyFinderContext : DbContext
    {
        public PartyFinderContext()
        {
        }

        public PartyFinderContext(DbContextOptions<PartyFinderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Business> Businesses { get; set; } = null!;
        public virtual DbSet<Chat> Chats { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<ReportUser> ReportUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=hildur.ucn.dk; User=dmaa0920_1086216; Database=dmaa0920_1086216; Password=Password1!;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>(entity =>
            {
                entity.HasKey(e => e.ProfileId)
                    .HasName("PK__Business__290C888477A0BA34");

                entity.ToTable("Business");

                entity.Property(e => e.ProfileId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProfileID");

                entity.Property(e => e.Cvr)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CVR");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Profile)
                    .WithOne(p => p.Business)
                    .HasForeignKey<Business>(d => d.ProfileId)
                    .HasConstraintName("FK__Business__Profil__656C112C");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("Chat");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Body)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationId).HasColumnName("DestinationID");

                entity.Property(e => e.SourceId).HasColumnName("SourceID");

                entity.Property(e => e.TimeSent).HasColumnType("date");

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.DestinationId)
                    .HasConstraintName("FK__Chat__Destinatio__6C190EBB");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.SourceId)
                    .HasConstraintName("FK__Chat__SourceID__6D0D32F4");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.EventName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Event__ProfileID__5BE2A6F2");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__Location__7944C870417A9B75");

                entity.ToTable("Location");

                entity.Property(e => e.EventId)
                    .ValueGeneratedNever()
                    .HasColumnName("EventID");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ZIP");

                entity.HasOne(d => d.Event)
                    .WithOne(p => p.Location)
                    .HasForeignKey<Location>(d => d.EventId)
                    .HasConstraintName("FK__Location__EventI__628FA481");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.ProfileId })
                    .HasName("PK__Match__2BD400F88BB4B5CC");

                entity.ToTable("Match");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.Match1).HasColumnName("Match");

            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReportUser>(entity =>
            {
                entity.ToTable("ReportUser");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccuserId).HasColumnName("AccuserID");

                entity.Property(e => e.Description)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.OffenderId).HasColumnName("OffenderID");

                entity.HasOne(d => d.Accuser)
                    .WithMany(p => p.ReportUserAccusers)
                    .HasForeignKey(d => d.AccuserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReportUse__Accus__68487DD7");

                entity.HasOne(d => d.Offender)
                    .WithMany(p => p.ReportUserOffenders)
                    .HasForeignKey(d => d.OffenderId)
                    .HasConstraintName("FK__ReportUse__Offen__693CA210");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
