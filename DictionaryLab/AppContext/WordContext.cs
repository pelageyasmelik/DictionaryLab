

using DictionaryLab.Model;
using Microsoft.EntityFrameworkCore;

public class WordContext:DbContext {
    public DbSet<WordDto> Words { get; set; }
    
    public WordContext(DbContextOptions<WordContext> options):base(options)
    {
        Database.EnsureCreated();
    }
    
    public WordContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("Data Source = WordLab3.db");
    }
}