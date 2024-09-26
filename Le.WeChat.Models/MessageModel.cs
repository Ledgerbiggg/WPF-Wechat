namespace Le.WeChat.Model;

public class MessageModel
{
    // 消息的标题
    public string Title { get; set; }

    // 消息的头像 URL
    public string AvatarUrl { get; set; }

    // 消息的时间
    public DateTime MessageTime { get; set; }

    // 消息的最后一条内容
    public string LastContent { get; set; }

    // 消息的 ID
    public string MessageId { get; set; }

    // 是否被禁言
    public bool IsMuted { get; set; }

    // 是否有未读的新消息
    public bool HasUnreadMessages { get; set; }
    
    // 是否被选中
    public bool IsSelected { get; set; }
    
}