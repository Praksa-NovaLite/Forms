using Forms.Models;
using Forms.Models.Exams;
using Microsoft.EntityFrameworkCore;

namespace Forms.FormsContext;

public class FormsDatabaseContext : DbContext
{
    public FormsDatabaseContext(DbContextOptions options) : base(options) { }

    public DbSet<Answer> Answers { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Exam> Exams { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exam>()
            .HasMany(e => e.Questions)
            .WithMany();
    }
}
