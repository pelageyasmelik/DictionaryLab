

using Microsoft.EntityFrameworkCore;

namespace DictionaryLab.Model;

public class WordRepository:IWordRepository {
    private readonly WordContext _dbContext;

    public WordRepository(WordContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<WordDto>> GetAll()
    {
        return await _dbContext.Words.ToListAsync();
    }

    public async Task AddNewWord(WordDto newWord)
    {
        _dbContext.Words.Add(newWord);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<WordDto>> SameRoot(string word)
    {
        return await _dbContext.Words.Where(w => word.Contains(w.root)).ToListAsync();
    }
}