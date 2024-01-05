namespace DictionaryLab.Model;

public interface IWordRepository {
    Task<List<WordDto>> GetAll();
    Task AddNewWord(WordDto newWord);
    Task<List<WordDto>> SameRoot(string word);
}