namespace DictionaryLab.Model;

public interface IWordRepository {
    public List<WordModel> GetAll();
    public void AddNewWord(WordModel newWord);
    public List<WordModel> SameRoot(string word);
}