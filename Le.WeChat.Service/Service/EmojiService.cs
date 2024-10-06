using Le.WeChat.Model.Model;
using Le.WeChat.Service.IService;

namespace Le.WeChat.Service.Service;

public class EmojiService : IEmojiService
{
    public IEnumerable<EmojiModel> GetAllEmojiModel()
    {
        return new List<EmojiModel>
        {
            new EmojiModel { EmojiName = "Grinning Face", EmojiCode = "😀" },
            new EmojiModel { EmojiName = "Beaming Face with Smiling Eyes", EmojiCode = "😁" },
            new EmojiModel { EmojiName = "Face with Tears of Joy", EmojiCode = "😂" },
            new EmojiModel { EmojiName = "Smiling Face with Heart-Eyes", EmojiCode = "😍" },
            new EmojiModel { EmojiName = "Smiling Face with Sunglasses", EmojiCode = "😎" },
            new EmojiModel { EmojiName = "Thinking Face", EmojiCode = "🤔" },
            new EmojiModel { EmojiName = "Crying Face", EmojiCode = "😢" },
            new EmojiModel { EmojiName = "Red Heart", EmojiCode = "❤️" },
            new EmojiModel { EmojiName = "Thumbs Up", EmojiCode = "👍" },
            new EmojiModel { EmojiName = "Clapping Hands", EmojiCode = "👏" },
            new EmojiModel { EmojiName = "Folded Hands", EmojiCode = "🙏" },
            new EmojiModel { EmojiName = "Rocket", EmojiCode = "🚀" },
            new EmojiModel { EmojiName = "Fire", EmojiCode = "🔥" },
            new EmojiModel { EmojiName = "Party Popper", EmojiCode = "🎉" },
            new EmojiModel { EmojiName = "Face Blowing a Kiss", EmojiCode = "😘" },
            new EmojiModel { EmojiName = "Winking Face", EmojiCode = "😉" },
            new EmojiModel { EmojiName = "Zany Face", EmojiCode = "🤪" },
            new EmojiModel { EmojiName = "Money-Mouth Face", EmojiCode = "🤑" },
            new EmojiModel { EmojiName = "Face Screaming in Fear", EmojiCode = "😱" },
            new EmojiModel { EmojiName = "Sleeping Face", EmojiCode = "😴" },
            new EmojiModel { EmojiName = "Relieved Face", EmojiCode = "😌" },
            new EmojiModel { EmojiName = "Face with Rolling Eyes", EmojiCode = "🙄" },
            new EmojiModel { EmojiName = "Exploding Head", EmojiCode = "🤯" },
            new EmojiModel { EmojiName = "Victory Hand", EmojiCode = "✌️" },
            new EmojiModel { EmojiName = "OK Hand", EmojiCode = "👌" }
        };
    }
}
