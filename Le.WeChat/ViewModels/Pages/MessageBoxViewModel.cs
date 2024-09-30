using System.Collections.ObjectModel;
using Le.WeChat.Model;
using Le.WeChat.Service.IService;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace LeWeChat.ViewModels.Pages;

public class MessageBoxViewModel : ViewModelBase
{
    private string _hh;

    public string HH
    {
        get { return "4515"; }
        set { SetProperty<string>(ref _hh, value); }
    }

    public DelegateCommand<Object> ClickMessageItemCommand { get; set; }
    private ObservableCollection<MessageModel> _messageModels;
    private readonly IMessageService _messageService;
    private readonly IRegionManager _regionManager;


    public ObservableCollection<MessageModel> MessageModels
    {
        get => _messageModels;
        set => SetProperty(ref _messageModels, value);
    }

    public MessageBoxViewModel(
        IMessageService messageService,
        IRegionManager regionManager
    )
    {
        _messageService = messageService;
        // 获取所有的消息内容
        MessageModels = new ObservableCollection<MessageModel>(_messageService.GetAllMessages());
        ClickMessageItemCommand = new DelegateCommand<object>(ClickMessageItem);
    }

    public void ClickMessageItem(object obj)
    {
        var messageModel = (MessageModel)obj;
        foreach (var message in MessageModels)
        {
            if (message.MessageId == messageModel.MessageId)
            {
                // 设置被点击的项为选中
                message.IsSelected = true;
            }
            else
            {
                // 其他项取消选中
                message.IsSelected = false;
            }
        }
    }
}