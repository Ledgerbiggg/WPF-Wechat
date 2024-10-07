using Le.WeChat.Model;
using Le.WeChat.Model.Model;

namespace Le.WeChat.Service.IService;

public interface IMessageService
{
    /// <summary>
    /// 获取所有消息
    /// </summary>
    /// <returns>返回消息模型的集合</returns>
    IEnumerable<MessageModel> GetAllMessages();
}