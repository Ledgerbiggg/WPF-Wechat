using System.Collections.ObjectModel;
using Le.WeChat.Model.Event;
using Le.WeChat.Model.Model;
using Le.WeChat.Service.IService;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace LeWeChat.ViewModels.Pages;

public class ChatDetailViewModel : BindableBase
{
    // 展示表情选择框的命令
    public DelegateCommand ShowEmojiCommand { get; set; }

    // 选择文件的,命令
    public DelegateCommand SelectFileCommand { get; set; }

    // 表情列表
    public ObservableCollection<EmojiModel> EmojiModels { get; set; }

    // 发送消息的命令
    public DelegateCommand SendCommand { get; set; }

    // 选择表情
    public DelegateCommand<EmojiModel> SelectEmojiCommand { get; set; }

    // 当前的消息内容
    private string _currentMessageContent;

    // 表情服务
    private IEmojiService _emojiService;

    // 当前的消息
    private MessageModel _messageModel;

    // 事件触发
    private readonly IEventAggregator _eventAggregator;

    // 是否显示弹窗表情
    private bool _isEmojiPopupOpen;

    public string CurrentMessageContent
    {
        get => _currentMessageContent;
        set => SetProperty(ref _currentMessageContent, value);
    }

    public bool IsEmojiPopupOpen
    {
        get { return _isEmojiPopupOpen; }
        set { SetProperty(ref _isEmojiPopupOpen, value); }
    }

    public MessageModel MessageModel
    {
        get => _messageModel;
        set => SetProperty(ref _messageModel, value); // 使用 SetProperty 更新字段并通知 UI
    }


    public ChatDetailViewModel(
        IEventAggregator eventAggregator,
        IEmojiService emojiService
    )
    {
        _eventAggregator = eventAggregator;
        _emojiService = emojiService;
        _eventAggregator.GetEvent<MessageEvent>().Subscribe(SubscribeChangeMessageCommand);
        ShowEmojiCommand = new DelegateCommand(ShowEmoji);
        SelectEmojiCommand = new DelegateCommand<EmojiModel>(SelectEmoji);
        SelectFileCommand = new DelegateCommand(SelectFile);
        SendCommand = new DelegateCommand(Send);
        /*发布消息的时候通知消息的滚动条滚动到最下面*/
        _eventAggregator.GetEvent<SendEvent>().Publish();
        /*获取所有表情*/
        EmojiModels = new ObservableCollection<EmojiModel>(_emojiService.GetAllEmojiModel());
    }

    private void SelectFile()
    {
        // 创建文件选择对话框
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "All files (*.*)|*.*";  // 设置文件过滤器

        // 如果用户选择了文件并点击确定
        if (openFileDialog.ShowDialog() == true)
        {
            string selectedFilePath = openFileDialog.FileName;
            // 在这里可以处理选中文件的路径，例如上传或显示
        }
    }

    /// <summary>
    /// 选择表情的时候新增对话内容
    /// </summary>
    /// <param name="emojiModel"></param>
    private void SelectEmoji(EmojiModel emojiModel)
    {
        CurrentMessageContent += emojiModel.EmojiCode;
    }

    /// <summary>
    /// 发送一条消息
    /// </summary>
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

    /// <summary>
    /// 如果切换对话内容就把当前文本清空
    /// </summary>
    /// <param name="messageModel"></param>
    private void SubscribeChangeMessageCommand(MessageModel messageModel)
    {
        /*如果这里切换的消息联系人就清空当前的消息*/
        if (_messageModel != null && messageModel.MessageId != _messageModel.MessageId)
        {
            CurrentMessageContent = string.Empty;
        }

        MessageModel = messageModel;
    }

    /// <summary>
    /// 展示表情选择框
    /// </summary>
    private void ShowEmoji()
    {
        // 切换 Popup 的显示状态
        IsEmojiPopupOpen = !IsEmojiPopupOpen;
    }
}