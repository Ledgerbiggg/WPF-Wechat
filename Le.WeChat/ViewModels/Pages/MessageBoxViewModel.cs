using System.Collections.ObjectModel;
using Le.WeChat.Model;
using Le.WeChat.Model.Event;
using Le.WeChat.Service.IService;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace LeWeChat.ViewModels.Pages;

public class MessageBoxViewModel : ViewModelBase
{

    public DelegateCommand<Object> ClickMessageItemCommand { get; set; }
    private ObservableCollection<MessageModel> _messageModels;
    private readonly IMessageService _messageService;
    private readonly IRegionManager _regionManager;
    private readonly IEventAggregator _eventAggregator;


    public ObservableCollection<MessageModel> MessageModels
    {
        get => _messageModels;
        set => SetProperty(ref _messageModels, value);
    }

    public MessageBoxViewModel(
        IMessageService messageService,
        IRegionManager regionManager,
        IEventAggregator eventAggregator
    )
    {
        _messageService = messageService;
        _regionManager = regionManager;
        _eventAggregator = eventAggregator;
        // 获取所有的消息内容
        MessageModels = new ObservableCollection<MessageModel>(_messageService.GetAllMessages());
        ClickMessageItemCommand = new DelegateCommand<object>(ClickMessageItem);
    }

    /// <summary>
    /// 点击消息条目触发的事件
    /// </summary>
    /// <param name="obj"></param>
    public void ClickMessageItem(object obj)
    {
        var messageModel = (MessageModel)obj;
        // 将点击的项设置为选中
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
        // 发布一条事件(将消息栏内部的消息修改成和这个相关的消息)
        _eventAggregator.GetEvent<MessageEvent>().Publish(messageModel);
    }
}