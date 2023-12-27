using Microsoft.EntityFrameworkCore;


public class SuffixContext:DbContext {
    public DbSet<SuffixContext> Suffixes { get; set; }
    
    public SuffixContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("Data Source = Lab3_2.db");
    }
}