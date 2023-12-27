using DictionaryLab.Model;
using Lab_2.Dictionary;
using Lab_2.View;

//
public class Program {
    public static void Main(String[] args) {
        WordRepository w = new WordRepository(new WordContext());
        View v = new View(new DictionaryModel(w));
        v.start(); 
    }
}