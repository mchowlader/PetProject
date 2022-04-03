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

            modelBuilder.Entity<CourseStudents>()
                .HasKey(cs => new {cs.StudentId, cs.CourseId});

            modelBuilder.Entity<CourseStudents>()
                .HasOne(x => x.Course)
                .WithMany(c => c.EnrollStudent)
                .HasForeignKey(k => k.CourseId);

            modelBuilder.Entity<CourseStudents>()
                .HasOne(x => x.Student)
                .WithMany(c => c.EnrollCourse)
                .HasForeignKey(k => k.StudentId);

            modelBuilder.Entity<Teacher>()
                .HasMany(c => c.Courses)
                .WithOne(t => t.Teacher);

            modelBuilder.Entity<Institutes>()
                .HasMany(s => s.Students);

            modelBuilder.Entity<Student>()
                .HasOne<Institutes>(e => e.Institutes)
                .WithMany(s => s.Students)
                .HasForeignKey(i => i.InstitutesId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Institutes>()
                .HasMany(s => s.Teachers);

            modelBuilder.Entity<Teacher>()
                .HasOne<Institutes>(e => e.Institutes)
                .WithMany(s => s.Teachers)
                .HasForeignKey(t => t.InstitutesId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Institutes> Institutes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
