using Le.WeChat.Model;
using Le.WeChat.Model.Event;
using Prism.Commands;
using Prism.Events;

namespace LeWeChat.ViewModels.Pages;

public class ContentBoxViewModel : ViewModelBase
{
    public DelegateCommand SendCommand { get; set; }
    private string _currentMessageContent;
    // 当前的消息
    private MessageModel _messageModel;
    private readonly IEventAggregator _eventAggregator;

    public string CurrentMessageContent
    {
        get => _currentMessageContent;
        set => SetProperty(ref _currentMessageContent, value);
    }
    public MessageModel MessageModel
    {
        get => _messageModel;
        set => SetProperty(ref _messageModel, value); // 使用 SetProperty 更新字段并通知 UI
    }

    
    public ContentBoxViewModel(IEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;
        _eventAggregator.GetEvent<MessageEvent>().Subscribe(SubscribeCommand);
        SendCommand = new DelegateCommand(Send);
    }

    private void Send()
    {
        _messageModel.AddMessageContents(CurrentMessageContent);
        CurrentMessageContent = string.Empty;
    }

    private void SubscribeCommand(MessageModel messageModel)
    {
        Console.WriteLine($"{messageModel.MessageContents}");
        MessageModel = messageModel; 
    }
}