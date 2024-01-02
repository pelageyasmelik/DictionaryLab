namespace DictionaryLab.Model;

public class WordDto
{
    public ulong id { get; set; }
    public string fullWord { get; set; }
    public string root { get; set; }
    public string suffixes { get; set; }

    public WordDto(){}

    public WordDto(WordModel w)
    {
        fullWord = w.fullWord;
        root = w.root;
        suffixes = string.Join(",", w.suffixes);
    }
}