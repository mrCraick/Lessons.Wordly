using Lessons.Wordly.Domain;

using Microsoft.EntityFrameworkCore;

namespace Lessons.Wordly.Infrastructure;

public class LessonWordlyContext : DbContext
{
    public DbSet<Noun> Nouns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var dataBaseProvider = new ConnectionStringProvider("db.db");
        optionsBuilder.UseSqlite(dataBaseProvider.GetConnectionString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Noun>().ToTable("nouns");
        modelBuilder.Entity<Noun>().Property(x => x.Iid).HasColumnName("IID");
        modelBuilder.Entity<Noun>().HasKey(x => x.Iid);
        modelBuilder.Entity<Noun>().Property(x => x.Word).HasColumnName("word");
    }
}