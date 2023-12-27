using Lab_2.Dictionary;

namespace Lab_2.View;


public class View
{ 
    private readonly DictionaryModel dictionary;

    public View(DictionaryModel _dictionary) {
        dictionary = _dictionary ?? throw new AggregateException();
    }
    public void start() {
        while (true) {
            string word = Console.ReadLine();
            if (word == "get all") dictionary.ListWords();
            else if (word == "q") break;
            else dictionary.AddWord(word);
        }   
    }
}