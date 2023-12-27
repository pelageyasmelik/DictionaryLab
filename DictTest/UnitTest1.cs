
using DictionaryLab.Model;
using Lab_2.Dictionary;
using Moq;
using NUnit.Framework;
using Assert = Xunit.Assert;

namespace TestProject1;

public class UnitTest1
{
    [Test]
    public void AddContact_ShouldAddtoList()
    {
        var moq = new Mock<IWordRepository>();
        moq.Setup(r => r.SameRoot("")).Returns(new List<WordModel>());

        var dictionary = new DictionaryModel(moq.Object);
        
        dictionary.AddWord("Mama");
        dictionary.AddWord("Papa");
        
        var words = dictionary.SameRoot("");
        
        Assert.Contains("Mama", words);
        Assert.Contains("Papa", words);
        
    }
    
   
}