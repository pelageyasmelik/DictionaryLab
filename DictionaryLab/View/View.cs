using Lab_2.Dictionary;

namespace Lab_2.View;

public class View
{ 
    private readonly DictionaryModel _dictionaryModel;

    public View(DictionaryModel dictionaryModel) {
        _dictionaryModel = dictionaryModel ?? throw new AggregateException();
    }
    public void start() {
        while (true) {
            string word = Console.ReadLine();
            if (word == "q") break;
            _dictionaryModel.AddWord(word);
        }   
    }
}