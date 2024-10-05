using System.Windows.Controls;
using Le.WeChat.Model;
using Le.WeChat.Model.Event;
using Prism.Events;

namespace LeWeChat.Views.Pages;

public partial class ContentBoxView : UserControl
{
    private ScrollViewer _chatScrollViewer { get; set; }
    private readonly IEventAggregator _eventAggregator;
    
    public ContentBoxView(IEventAggregator eventAggregator)
    {
        InitializeComponent();
        _chatScrollViewer = ChatScrollViewer;
        _eventAggregator = eventAggregator;
        /*订阅收到消息的时候滚动条划到最下面*/
        eventAggregator.GetEvent<SendEvent>().Subscribe(SubscribeCommand);
    }

    private void SubscribeCommand()
    {
        _chatScrollViewer.ScrollToBottom();
    }
}