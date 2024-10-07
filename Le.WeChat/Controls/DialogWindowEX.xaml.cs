using System.Windows;
using Prism.Services.Dialogs;

namespace LeWeChat.Controls;

public partial class DialogWindowEX : Window, IDialogWindow
{
    public DialogWindowEX()
    {
        InitializeComponent();
    }

    public IDialogResult Result { get; set; }
}