using System.Windows;
using Prism.Services.Dialogs;

namespace LeWeChat.Views.Pages;

public partial class DialogWindowEX : Window, IDialogWindow
{
    public DialogWindowEX()
    {
        InitializeComponent();
    }

    public IDialogResult Result { get; set; }
}