using Prism.Mvvm;

namespace Le.WeChat.Model;

public class MessageContentModel : BindableBase
{
    // 是否是我发送的消息
    public bool IsSentByMe { get; set; }

    // 发送时间
    public DateTime SentTime { get; set; }

    // 消息的内容
    public string Content { get; set; }

    // 消息的类型 (例如文本、图片、语音等)
    public MessageType ContentType { get; set; }
}

// 消息类型的枚举
public enum MessageType
{
    Text,      // 文本消息
    Image,     // 图片消息
    Voice,     // 语音消息
    Video,     // 视频消息
    File       // 文件消息
}
