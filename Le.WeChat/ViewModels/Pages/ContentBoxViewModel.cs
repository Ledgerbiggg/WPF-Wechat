using Le.WeChat.Model;
using Le.WeChat.Model.Event;
using Prism.Events;

namespace LeWeChat.ViewModels.Pages;

public class ContentBoxViewModel : ViewModelBase
{
    private readonly IEventAggregator _eventAggregator;
    private MessageModel _messageModel;

    public MessageModel MessageModel
    {
        get => _messageModel;
        set => SetProperty(ref _messageModel, value); // 使用 SetProperty 更新字段并通知 UI
    }

    
    public ContentBoxViewModel(IEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;
        _eventAggregator.GetEvent<MessageEvent>().Subscribe(SubscribeCommand);
    }

    private void SubscribeCommand(MessageModel messageModel)
    {
        Console.WriteLine($"{messageModel.MessageContents}");
        MessageModel = messageModel; 
    }
}