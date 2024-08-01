namespace Final_Assessment.Data
{
    using Final_Assessment.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Colleges> Colleges { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<CoursesEnrolled> CoursesEnrolled { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CoursesEnrolled>()
                .HasKey(ce => new { ce.CourseId, ce.CollegeId });

            modelBuilder.Entity<CoursesEnrolled>()
                .HasOne(ce => ce.Course)
                .WithMany(c => c.CoursesEnrolled)
                .HasForeignKey(ce => ce.CourseId);

            modelBuilder.Entity<CoursesEnrolled>()
                .HasOne(ce => ce.College)
                .WithMany(c => c.CoursesEnrolled)
                .HasForeignKey(ce => ce.CollegeId);
        }
    }

}
