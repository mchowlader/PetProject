using ManagementSystem.Academy.Entities;
using ManagementSystem.Membership.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Academy.Contexts
{
    public class AcademyDbContext :DbContext, IAcademyDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public AcademyDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("AspNetUsers", x => x.ExcludeFromMigrations())
                .HasMany<Institutes>()
                .WithOne(x => x.AdminUser);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Institutes> Institutes { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Course> Courses { get; set; }
    }
}
