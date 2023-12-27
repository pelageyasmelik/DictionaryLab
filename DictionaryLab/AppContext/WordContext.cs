

using DictionaryLab.Model;
using Microsoft.EntityFrameworkCore;

public class WordContext:DbContext {
    public DbSet<WordModel> Words { get; set; }
    
    public WordContext()
    {
        Database.EnsureCreated();
    }
    
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("Data Source = WordLab3.db");
    }
}