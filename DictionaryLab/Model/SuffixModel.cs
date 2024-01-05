using System.ComponentModel.DataAnnotations;
namespace DictionaryLab.Model;

public class SuffixModel
{
    [Key] public Guid Id { get; set; }
    public string suffix { get; set; }
}