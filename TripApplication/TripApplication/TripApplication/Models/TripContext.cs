using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TripApplication.Models
{
    public partial class TripContext : DbContext
    {
        public TripContext()
        {
        }

        public TripContext(DbContextOptions<TripContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Limousine> Limousines { get; set; } = null!;
        public virtual DbSet<LimousineType> LimousineTypes { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Route> Routes { get; set; } = null!;
        public virtual DbSet<Trip> Trips { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=localhost; database=TripManagement; Integrated security=true; TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("Account");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("money")
                    .HasColumnName("amount");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.Customer)
                    .HasMaxLength(50)
                    .HasColumnName("customer");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.SeatsStatus).HasColumnName("seatsStatus");

                entity.Property(e => e.TripId).HasColumnName("trip_id");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Booking_Account");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("FK_Booking_Trip");
            });

            modelBuilder.Entity<Limousine>(entity =>
            {
                entity.ToTable("Limousine");

                entity.Property(e => e.LimousineId).HasColumnName("limousine_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.NumberCols).HasColumnName("numberCols");

                entity.Property(e => e.NumberRows).HasColumnName("numberRows");

                entity.Property(e => e.Plate)
                    .HasMaxLength(50)
                    .HasColumnName("plate");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Limousines)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK_Limousine_Limousine_Type");
            });

            modelBuilder.Entity<LimousineType>(entity =>
            {
                entity.ToTable("Limousine_Type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasColumnName("unit_price");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocationCode);

                entity.ToTable("Location");

                entity.Property(e => e.LocationCode)
                    .HasMaxLength(10)
                    .HasColumnName("location_code");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(50)
                    .HasColumnName("location_name");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("Route");

                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.Property(e => e.Distance).HasColumnName("distance");

                entity.Property(e => e.RouteFrom)
                    .HasMaxLength(10)
                    .HasColumnName("route_from");

                entity.Property(e => e.RouteName).HasColumnName("route_name");

                entity.Property(e => e.RouteTo)
                    .HasMaxLength(10)
                    .HasColumnName("route_to");

                entity.HasOne(d => d.RouteFromNavigation)
                    .WithMany(p => p.RouteRouteFromNavigations)
                    .HasForeignKey(d => d.RouteFrom)
                    .HasConstraintName("FK_Route_Location");

                entity.HasOne(d => d.RouteToNavigation)
                    .WithMany(p => p.RouteRouteToNavigations)
                    .HasForeignKey(d => d.RouteTo)
                    .HasConstraintName("FK_Route_Location1");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("Trip");

                entity.Property(e => e.TripId).HasColumnName("trip_id");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .HasColumnName("create_by");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.LimousineId).HasColumnName("limousine_id");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.Property(e => e.Slot).HasColumnName("slot");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.CreateBy)
                    .HasConstraintName("FK_Trip_Account");

                entity.HasOne(d => d.Limousine)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.LimousineId)
                    .HasConstraintName("FK_Trip_Limousine");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.RouteId)
                    .HasConstraintName("FK_Trip_Route");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
