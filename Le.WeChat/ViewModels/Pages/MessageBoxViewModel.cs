using System.Collections.ObjectModel;
using Le.WeChat.Model;
using Le.WeChat.Service.IService;
using Prism.Mvvm;
using Prism.Regions;

namespace LeWeChat.ViewModels.Pages;

public class MessageBoxViewModel : ViewModelBase
{
    private ObservableCollection<MessageModel> _messageModels;
    private readonly IMessageService _messageService;
    private readonly IRegionManager _regionManager;


    public ObservableCollection<MessageModel> MessageModels
    {
        get => _messageModels;
        set => SetProperty(ref _messageModels, value);
    }

    public MessageBoxViewModel(
        IMessageService messageService, 
        IRegionManager regionManager
    )
    {
        _messageService = messageService;
        // 中间的消息内容
        MessageModels = new ObservableCollection<MessageModel>(_messageService.GetAllMessages());
    }

}