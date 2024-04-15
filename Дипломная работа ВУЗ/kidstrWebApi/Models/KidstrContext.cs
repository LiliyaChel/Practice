using Microsoft.EntityFrameworkCore;

namespace kidstrWebApi.Models
{
    public class KidstrContext : DbContext
    {
        public DbSet<AddServ> AddServs { get; set; }
        public DbSet<AddServOrdr> AddServOrdrs { get; set; }
        public DbSet<Age> Ages { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Ordr> Ordrs { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceAge> ServiceAges { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<User> Users { get; set; }

        public KidstrContext(DbContextOptions<KidstrContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddServ>(entity =>
            {
                entity.HasKey(e => e.IdAdd);
                entity.Property(e => e.IdAdd).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AddServOrdr>(entity =>
            {
                entity.HasKey(e => new { e.IdAdd, e.IdOrdr });

            });

            modelBuilder.Entity<Age>(entity =>
            {
                entity.HasKey(e => e.IdGroup);
                entity.Property(e => e.IdGroup).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Day>(entity =>
            {
                entity.HasKey(e => new { e.IdServ, e.DayNum });
            });

            modelBuilder.Entity<Direction>(entity =>
            {
                entity.HasKey(e => e.IdDir);
                entity.Property(e => e.IdDir).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmp);
            });

            modelBuilder.Entity<Guide>(entity =>
            {
                entity.HasKey(e => new { e.IdEmp, e.IdServ });
            });

            modelBuilder.Entity<Ordr>(entity =>
            {
                entity.HasKey(e => e.IdOrdr);
                entity.Property(e => e.IdOrdr).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasKey(e => e.IdPrice);
                entity.Property(e => e.IdPrice).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.IdServ);
                entity.Property(e => e.IdServ).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ServiceAge>(entity =>
            {
                entity.HasKey(e => new { e.IdServ, e.IdGroup });
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStat);
                entity.Property(e => e.IdStat).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Models.Type>(entity =>
            {
                entity.HasKey(e => e.IdType);
                entity.Property(e => e.IdType).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdEmp);
            });
        }
    }
}
