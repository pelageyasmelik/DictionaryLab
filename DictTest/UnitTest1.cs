using Lab_2.Dictionary;
using Xunit;
namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void DictionaryModel_ShouldBeZeroElement() {
        var DictionaryModel = new DictionaryModel();
        Assert.Equal(DictionaryModel.ListWords().Count, 0);
    }
    
    [Xunit.Theory]
    [InlineData("new word")]
    [InlineData("new word 2")]
    [InlineData("new word 3")]
    public void DictionaryModel_ShouleBe_ReturnExpected(string word) {
        var DictionaryModel = new DictionaryModel();
        Word w = new Word(word, new List<string>());
        DictionaryModel.AddNewWord(w);
        
        Assert.Equal(DictionaryModel.ListWords().Count,1);
    }
    
    
    [Xunit.Theory]
    [InlineData("new word")]
    [InlineData("new word 2")]
    [InlineData("new word 3")]
    public void AddNewWord_ShouldBe_ReturnExpected(string word) {
        var DictionaryModel = new DictionaryModel();
        //слово не было
        Assert.False(DictionaryModel.checkWord(word));
        
        //добавим новое слово
        Word w = new Word(word, new List<string>());
        DictionaryModel.AddNewWord(w); 

        Assert.Equal(DictionaryModel.ListWords().Count,1);
    }
    
    [Fact]
    public void AddNewWord_ShouldBe_ReturnFales() {
        var DictionaryModel = new DictionaryModel();
        Word w = new Word("root", new List<string>{"suffix1"});
        DictionaryModel.AddNewWord(w);
        Assert.Equal(DictionaryModel.ListWords().Count,1);
        
        //слово уже было
        Assert.True(DictionaryModel.checkWord("rootsuffix1"));
        
        //добавим новое слово
        DictionaryModel.AddNewWord(w);

        Assert.Equal(DictionaryModel.ListWords().Count,1);
    }

    [Fact]
    public void SameRoot_ShouldBe_ReturnExpected() {
        var DictionaryModel = new DictionaryModel();
        Word w1 = new Word("root", new List<string>{"suffix1"});
        Word w2 = new Word("root", new List<string>{"suffix2"});
        Word w3 = new Word("root", new List<string>{"suffix3"});
        DictionaryModel.AddNewWord(w1);
        DictionaryModel.AddNewWord(w2);
        DictionaryModel.AddNewWord(w3);
        Assert.Equal(DictionaryModel.ListWords().Count,3);
        
        //слово уже было
        Assert.True(DictionaryModel.checkWord("rootsuffix1"));

        Assert.Equal(DictionaryModel.SameRoot("rootsuffix1").Count,3);
    }
   
}