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

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
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
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Business>(entity =>
            {
                entity.HasKey(e => e.ProfileId)
                    .HasName("PK__Business__290C8884937CC50C");

                entity.ToTable("Business");

                entity.Property(e => e.ProfileId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProfileID");

                entity.Property(e => e.Cvr)
                    .HasMaxLength(50)
                    .HasColumnName("CVR");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Profile)
                    .WithOne(p => p.Business)
                    .HasForeignKey<Business>(d => d.ProfileId)
                    .HasConstraintName("FK__Business__Profil__78D3EB5B");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("Chat");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Body).HasMaxLength(250);

                entity.Property(e => e.DestinationId).HasColumnName("DestinationID");

                entity.Property(e => e.SourceId).HasColumnName("SourceID");

                entity.Property(e => e.TimeSent).HasColumnType("date");

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.DestinationId)
                    .HasConstraintName("FK__Chat__Destinatio__7F80E8EA");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.SourceId)
                    .HasConstraintName("FK__Chat__SourceID__00750D23");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.EventName).HasMaxLength(50);

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Event__ProfileID__6F4A8121");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__Location__7944C870154670A2");

                entity.ToTable("Location");

                entity.Property(e => e.EventId)
                    .ValueGeneratedNever()
                    .HasColumnName("EventID");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Zip)
                    .HasMaxLength(50)
                    .HasColumnName("ZIP");

                entity.HasOne(d => d.Event)
                    .WithOne(p => p.Location)
                    .HasForeignKey<Location>(d => d.EventId)
                    .HasConstraintName("FK__Location__EventI__75F77EB0");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.ProfileId })
                    .HasName("PK__Match__2BD400F844E16831");

                entity.ToTable("Match");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.Match1).HasColumnName("Match");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__Match__EventID__7226EDCC");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK__Match__ProfileID__731B1205");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AspNetUserForeignKey).HasMaxLength(450);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.HasOne(d => d.AspNetUserForeignKeyNavigation)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.AspNetUserForeignKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Profile__AspNetU__6C6E1476");
            });

            modelBuilder.Entity<ReportUser>(entity =>
            {
                entity.ToTable("ReportUser");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccuserId).HasColumnName("AccuserID");

                entity.Property(e => e.Description).HasMaxLength(400);

                entity.Property(e => e.OffenderId).HasColumnName("OffenderID");

                entity.HasOne(d => d.Accuser)
                    .WithMany(p => p.ReportUserAccusers)
                    .HasForeignKey(d => d.AccuserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReportUse__Accus__7BB05806");

                entity.HasOne(d => d.Offender)
                    .WithMany(p => p.ReportUserOffenders)
                    .HasForeignKey(d => d.OffenderId)
                    .HasConstraintName("FK__ReportUse__Offen__7CA47C3F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
