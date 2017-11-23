using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LearningSystem.Data.Models;


namespace LearningSystem.Data
{
    public class LearningSystemDbContext : IdentityDbContext<User>
    {

        public DbSet<Course> Courses { get; set; }

        public DbSet<Article> Articles { get; set; }

        public LearningSystemDbContext(DbContextOptions<LearningSystemDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.CourseId, sc.StudentId  });

            builder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(sc => sc.CourseId);


            builder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Courses)
                .HasForeignKey(sc => sc.StudentId);
                

            builder.Entity<User>()
                .HasMany(u => u.Trainings)
                .WithOne(t => t.Trainer)
                .HasForeignKey(t => t.TrainerId);

            builder.Entity<User>()
                .HasMany(u => u.Articles)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId);

            base.OnModelCreating(builder);
           
        }
    }
}
