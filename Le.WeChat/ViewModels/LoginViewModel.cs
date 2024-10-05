using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace LeWeChat.ViewModels;

public class LoginViewModel:BindableBase, IDialogAware
{
    public DelegateCommand EnterWeChatCommand { get;set; }
    public string Title => "欢迎使用微信";
    public event Action<IDialogResult>? RequestClose;

    public LoginViewModel()
    {
        EnterWeChatCommand = new DelegateCommand(EnterWeChat);
    }

    private void EnterWeChat()
    {
        RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
    }


    public bool CanCloseDialog()
    {
        return true;
    }

    public void OnDialogClosed()
    {
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
    }


}