using Le.WeChat.Model.Model;

namespace Le.WeChat.Service.IService;

public interface IEmojiService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerable<EmojiModel> GetAllEmojiModel();
}