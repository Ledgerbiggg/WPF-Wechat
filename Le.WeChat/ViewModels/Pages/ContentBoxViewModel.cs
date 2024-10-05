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
        /*发布消息的时候通知消息的滚动条滚动到最下面*/
        _eventAggregator.GetEvent<SendEvent>().Publish();
    }

    private void Send()
    {
        if (string.IsNullOrEmpty(CurrentMessageContent))
        {
            return;
        }
        _messageModel.AddMessageContents(CurrentMessageContent);
        CurrentMessageContent = string.Empty;
        /*发布消息的时候通知消息的滚动条滚动到最下面*/
        _eventAggregator.GetEvent<SendEvent>().Publish();
    }

    private void SubscribeCommand(MessageModel messageModel)
    {
        /*如果这里切换的消息联系人就清空当前的消息*/
        if (_messageModel!=null && messageModel.MessageId != _messageModel.MessageId)
        {
            CurrentMessageContent=string.Empty;
        }
        MessageModel = messageModel; 

    }
}