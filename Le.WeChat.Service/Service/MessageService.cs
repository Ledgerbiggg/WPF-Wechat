using System.Collections.ObjectModel;
using Le.WeChat.Model;
using Le.WeChat.Service.IService;

namespace Le.WeChat.Service.Service;

public class MessageService : IMessageService
{
    public IEnumerable<MessageModel> GetAllMessages()
    {
        var messages = new List<MessageModel>
        {
            new()
            {
                Title = "张三",
                AvatarUrl = "/Assets/Images/user1.jpg",
                MessageTime = DateTime.Now.AddMinutes(-5),
                MessageId = "1",
                IsMuted = false,
                HasUnreadMessages = true,
                IsSelected = false,
                MessageContents = new ObservableCollection<MessageContentModel>()
                {
                    new MessageContentModel
                    {
                        IsSentByMe = true,
                        SentTime = DateTime.Now.AddMinutes(-15),
                        Content = "张三，你好！明天要开会吗？",
                        ContentType = MessageType.Text
                    },
                    new MessageContentModel
                    {
                        IsSentByMe = false,
                        SentTime = DateTime.Now.AddMinutes(-10),
                        Content = "明天下午有空吗？可以聊一下项目进展。",
                        ContentType = MessageType.Text
                    },
                    new MessageContentModel
                    {
                        IsSentByMe = true,
                        SentTime = DateTime.Now.AddMinutes(-5),
                        Content = "明天下午可以，我们约个时间。",
                        ContentType = MessageType.Text
                    }
                }
            },
            new()
            {
                Title = "李四",
                AvatarUrl = "/Assets/Images/user2.jpg",
                MessageTime = DateTime.Now.AddMinutes(-20),
                MessageId = "2",
                IsMuted = false,
                HasUnreadMessages = false,
                IsSelected = false,
                MessageContents = new ObservableCollection<MessageContentModel>()
                {
                    new MessageContentModel
                    {
                        IsSentByMe = true,
                        SentTime = DateTime.Now.AddMinutes(-30),
                        Content = "李四，报告的进度怎么样了？",
                        ContentType = MessageType.Text
                    },
                    new MessageContentModel
                    {
                        IsSentByMe = false,
                        SentTime = DateTime.Now.AddMinutes(-25),
                        Content = "我刚好在处理，稍后发给你。",
                        ContentType = MessageType.Text
                    },
                    new MessageContentModel
                    {
                        IsSentByMe = false,
                        SentTime = DateTime.Now.AddMinutes(-20),
                        Content = "收到，稍后发给你。",
                        ContentType = MessageType.Text
                    }
                }
            },
            new()
            {
                Title = "王五",
                AvatarUrl = "/Assets/Images/user3.jpg",
                MessageTime = DateTime.Now.AddMinutes(-45),
                MessageId = "3",
                IsMuted = true,
                HasUnreadMessages = true,
                IsSelected = false,
                MessageContents = new ObservableCollection<MessageContentModel>()
                {
                    new MessageContentModel
                    {
                        IsSentByMe = false,
                        SentTime = DateTime.Now.AddMinutes(-55),
                        Content = "下午三点开会，记得准时参加。",
                        ContentType = MessageType.Text
                    },
                    new MessageContentModel
                    {
                        IsSentByMe = true,
                        SentTime = DateTime.Now.AddMinutes(-50),
                        Content = "好的，我会准时的。",
                        ContentType = MessageType.Text
                    }
                }
            },
            new()
            {
                Title = "赵六",
                AvatarUrl = "/Assets/Images/user4.jpg",
                MessageTime = DateTime.Now.AddMinutes(-60),
                MessageId = "4",
                IsMuted = false,
                HasUnreadMessages = false,
                IsSelected = false,
                MessageContents = new ObservableCollection<MessageContentModel>()
                {
                    new MessageContentModel
                    {
                        IsSentByMe = true,
                        SentTime = DateTime.Now.AddMinutes(-70),
                        Content = "赵六，项目进度有问题吗？项目进度有问题吗?项目进度有问题吗?项目进度有问题吗?项目进度有问题吗?项目进度有问题吗?项目进度有问题吗?项目进度有问题吗?项目进度有问题吗?",
                        ContentType = MessageType.Text
                    },
                    new MessageContentModel
                    {
                        IsSentByMe = false,
                        SentTime = DateTime.Now.AddMinutes(-65),
                        Content = "没有问题，进展顺利，我等下发你更新。",
                        ContentType = MessageType.Text
                    },
                    new MessageContentModel
                    {
                        IsSentByMe = false,
                        SentTime = DateTime.Now.AddMinutes(-60),
                        Content = "项目进度有更新，请查阅。",
                        ContentType = MessageType.Text
                    }
                }
            },
            new()
            {
                Title = "小明",
                AvatarUrl = "/Assets/Images/user5.jpg",
                MessageTime = DateTime.Now.AddMinutes(-90),
                MessageId = "5",
                IsMuted = false,
                HasUnreadMessages = true,
                IsSelected = false,
                MessageContents = new ObservableCollection<MessageContentModel>()
                {
                    new MessageContentModel
                    {
                        IsSentByMe = true,
                        SentTime = DateTime.Now.AddMinutes(-100),
                        Content = "中午有什么安排？",
                        ContentType = MessageType.Text
                    },
                    new MessageContentModel
                    {
                        IsSentByMe = false,
                        SentTime = DateTime.Now.AddMinutes(-95),
                        Content = "没啥事，要不要一起吃饭？",
                        ContentType = MessageType.Text
                    },
                    new MessageContentModel
                    {
                        IsSentByMe = true,
                        SentTime = DateTime.Now.AddMinutes(-90),
                        Content = "好啊，一起去吧。",
                        ContentType = MessageType.Text
                    }
                }
            }
        };

        return messages;
    }
}