using System;
using System.Collections.ObjectModel;
using System.Linq;
using DictionaryInterface.Models;
using DictionaryInterface.Views;
using DictionaryLab.Model;
using DynamicData;
using Lab_2.Dictionary;
using ReactiveUI;

namespace DictionaryInterface.ViewModels;

public class DictionaryVM : ViewModelBase
{
    private WordContext _wordContext;
    private WordRepository _wordRepository;
    
    public ObservableCollection<WordDto> WordList { get; set; } = new ObservableCollection<WordDto>();
    public ObservableCollection<Node> Nodes { get; set; } = new ObservableCollection<Node>();
    
    public string _InputTextBox;
    public string InputTextBox
    {
        get { return _InputTextBox; }
        set
        {
            this.RaiseAndSetIfChanged(ref _InputTextBox, value);
        }
    }

    public DictionaryVM()
    {
        _wordContext = new WordContext();
        _wordRepository = new WordRepository(_wordContext);
        var words = _wordContext.Words.ToList();
        WordList.AddRange(words);
        
    }

    public void Search()
    {
        Nodes.Clear();
        if (!string.IsNullOrWhiteSpace(InputTextBox))
        {
            var matchingWords = WordList
                .Where(word =>
                    word.root.StartsWith(InputTextBox, StringComparison.OrdinalIgnoreCase) ||
                    InputTextBox.StartsWith(word.root, StringComparison.OrdinalIgnoreCase)
                );

            Nodes.Add(new Node(_InputTextBox, new ObservableCollection<Node>()));
            foreach (var wl in matchingWords)
            {
                Nodes[0].SubNodes.Add(new Node(wl.fullWord));
            }
        }
    }


    public void AddToDictionary()
    {
        var dialog = new DialogWindow();
        dialog.DataContext = new DialogVM(this, dialog);
        dialog.Show();
    }

    public void ActuallyAdd(string fullWord, string root, string suffixes)
    {
        var word = new WordDto
        {
            fullWord = fullWord,
            root = root,
            suffixes = suffixes,
            id = (ulong) (WordList.Count + 1)
        };
        WordList.Add(word);
        _wordContext.Words.Add(word);
        _wordContext.SaveChanges();

    }
}