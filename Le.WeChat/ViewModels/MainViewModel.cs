using Le.WeChat.Model;
using Le.WeChat.Service.IService;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace LeWeChat.ViewModels;

public class MainViewModel : BindableBase
{
    private readonly IDialogService _dialogService;
    private readonly IMessageService _messageService;
    private IEnumerable<MessageModel> _messageModels;

    public IEnumerable<MessageModel> MessageModels
    {
        get { return _messageModels; }
        set { SetProperty(ref _messageModels, value); }
    }


    public MainViewModel(
        IDialogService dialogService,
        IMessageService messageService
    )
    {
        _dialogService = dialogService;
        _messageService = messageService;
        
        // 在启动主窗口之前启动登录窗口
        // OpenLoginWindow();
        
        // 中间的消息内容
        MessageModels = _messageService.GetAllMessages();

    }

    private void OpenLoginWindow()
    {
        _dialogService.ShowDialog("LoginView", result =>
        {
            if (result.Result != ButtonResult.OK)
            {
                Environment.Exit(0);
            }
            else
            {
                var su = result.Parameters.GetValue<SysUserModel>("user");
            }
        });
    }
}