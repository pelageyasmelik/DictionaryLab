namespace Lab_2.Dictionary;


public class DictionaryModel {
    private SortedSet<Word> _dictionary = new();

    public SortedSet<Word> ListWords() {
        Console.WriteLine("List Words: ");
        foreach (var word in _dictionary)
            Console.WriteLine(word.GetWord());
        return _dictionary;
    }

    public void AddWord(string word) {
        if (!checkWord(word)) {
            Console.Write($"Unknown word. Want to add it to the dictionary? (Y/N)");
            if (Console.ReadLine().Equals("Y")) {
                Word newWord = new Word(word); 
                AddNewWord(newWord);
            }
            return;
        }
        Console.WriteLine("Famous words:");
        var WordsFromTheSameRoot = SameRoot(word);
        foreach (var w in WordsFromTheSameRoot)
            Console.WriteLine(w.GetWord());
    }

    public bool checkWord(string word) {
        return _dictionary.Any(w => w.fullWord == word);
    }
    
    public void AddNewWord(Word word) {
        _dictionary.Add(word);
        Console.WriteLine($"The word {word} has been added.");
    }

    public SortedSet<Word> SameRoot(string word) {
        SortedSet<Word> result = new();
        foreach (var w in _dictionary)
            if (word.Contains(w.root)) result.Add(w);
        return result;
    }
}