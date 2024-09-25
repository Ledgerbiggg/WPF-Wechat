using Le.WeChat.Model;
using Le.WeChat.Service.IService;

namespace Le.WeChat.Service.Service;

public class MessageService : IMessageService
{
    public IEnumerable<MessageModel> GetAllMessages()
    {
        // 创建一些假数据
        return new List<MessageModel>
        {
            new()
            {
                Title = "Hello World",
                AvatarUrl = "https://example.com/avatar1.png",
                MessageTime = DateTime.Now.AddMinutes(-5),
                LastContent = "This is the last message content.",
                MessageId = "1",
                IsMuted = false,
                HasUnreadMessages = true
            },
            new()
            {
                Title = "Good Morning",
                AvatarUrl = "https://example.com/avatar2.png",
                MessageTime = DateTime.Now.AddMinutes(-10),
                LastContent = "Another message content.",
                MessageId = "2",
                IsMuted = false,
                HasUnreadMessages = false
            },
            new()
            {
                Title = "Meeting Reminder",
                AvatarUrl = "https://example.com/avatar3.png",
                MessageTime = DateTime.Now.AddMinutes(-20),
                LastContent = "Don't forget the meeting at 3 PM.",
                MessageId = "3",
                IsMuted = true,
                HasUnreadMessages = true
            },
            new()
            {
                Title = "Project Update",
                AvatarUrl = "https://example.com/avatar4.png",
                MessageTime = DateTime.Now.AddMinutes(-30),
                LastContent = "The project is on track for completion.",
                MessageId = "4",
                IsMuted = false,
                HasUnreadMessages = false
            },
            new()
            {
                Title = "Lunch Plans",
                AvatarUrl = "https://example.com/avatar5.png",
                MessageTime = DateTime.Now.AddMinutes(-45),
                LastContent = "Who wants to join for lunch?",
                MessageId = "5",
                IsMuted = false,
                HasUnreadMessages = true
            }
        };
    }
}