using DictionaryInterface.Views;
using ReactiveUI;

namespace DictionaryInterface.ViewModels;

public class DialogVM : ViewModelBase
{
    private string _root;
    private string _suffix1;
    private string _suffix2;
    private string _fullword;
    
    private DictionaryVM _dictViewModel;
    private DialogWindow _dialog;
    
    public string Root
    {
        get => _root;
        set
        {
            this.RaiseAndSetIfChanged(ref _root, value);
            UpdateButtonEnabledState();
        } 
    }
    
    public string Suffix1
    {
        get => _suffix1;
        set => this.RaiseAndSetIfChanged(ref _suffix1, value);
    }
    
    public string Suffix2
    {
        get => _suffix2;
        set => this.RaiseAndSetIfChanged(ref _suffix2, value);
    }
    
    private bool _isButtonEnabled;
    public bool IsButtonEnabled
    {
        get => _isButtonEnabled;
        set => this.RaiseAndSetIfChanged(ref _isButtonEnabled, value);
    }

    public DialogVM(DictionaryVM dictViewModel, DialogWindow dialog)
    {
        _dictViewModel = dictViewModel;
        _dialog = dialog;
    }
    
    private void UpdateButtonEnabledState()
    {
        IsButtonEnabled = !string.IsNullOrWhiteSpace(Root);
    }
    
    private void TextChanged()
    {
        UpdateButtonEnabledState();
    }

    public void Add()
    {
        _fullword = _root+_suffix1+_suffix2;
        _dictViewModel.ActuallyAdd(_fullword, _root, $"{_suffix1},{_suffix2}");
        _dialog.Close();
    }
}