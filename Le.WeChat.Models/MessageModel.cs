using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace Le.WeChat.Model;
public class MessageModel : BindableBase
{
    // 消息的标题
    public string Title { get; set; }

    // 消息的头像 URL
    public string AvatarUrl { get; set; }
    

    // 消息的 ID
    public string MessageId { get; set; }

    // 是否被禁言
    public bool IsMuted { get; set; }

    // 是否有未读的新消息
    public bool HasUnreadMessages { get; set; }
    
    // 消息内容：存储对话记录
    public ObservableCollection<MessageContentModel> MessageContents { get; set; }

    // 是否被选中
    private bool _isSelected;
    
    // 消息的时间
    private DateTime _messageTime;
    
    // 新增一条消息
    public void AddMessageContents(string content, MessageType messageType = MessageType.Text)
    {
        MessageContents.Add(new MessageContentModel
        {
            Content = content,
            SentTime = DateTime.Now,
            ContentType = messageType,
            IsSentByMe = true
        });
        
    }

    // 是否被选中 (响应式属性)
    public bool IsSelected
    {
        get => _isSelected;
        set => SetProperty(ref _isSelected, value); // 使用 SetProperty 进行响应式更新
    }

    // 最后一条消息的内容
    public string LastContent
    {
        get
        {
            // 如果MessageContents为空，则返回空字符串
            if (MessageContents == null || MessageContents.Count == 0)
                return string.Empty;

            // 返回最后一个MessageContentModel的内容
            return MessageContents.Last().Content;
        }
    }
    
    public DateTime MessageTime
    {
        get => MessageContents.Last().SentTime;
        set => SetProperty(ref _messageTime, value);
    }
}
