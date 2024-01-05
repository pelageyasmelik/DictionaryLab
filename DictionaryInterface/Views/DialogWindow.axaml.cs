using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DictionaryInterface.Views;

public partial class DialogWindow : Window
{
    public DialogWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}