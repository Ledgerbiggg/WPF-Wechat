using Le.WeChat.Model;
using Le.WeChat.Service.IService;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace LeWeChat.ViewModels;

public class MainViewModel : BindableBase
{
    public DelegateCommand<Object> ToMessageBox { get; set; }
    public DelegateCommand<Object> ToContactsBox { get; set; }
    public DelegateCommand<Object> ToFavoritesBox { get; set; }
    private readonly IDialogService _dialogService;
    private readonly IRegionManager _regionManager;


    public MainViewModel(
        IDialogService dialogService,
        IRegionManager regionManager
    )
    {
        _dialogService = dialogService;
        _regionManager = regionManager;
        ToMessageBox = new DelegateCommand<object>(NavigateToMessageBox);
        ToContactsBox = new DelegateCommand<object>(NavigateToContactsBox);
        ToFavoritesBox = new DelegateCommand<object>(NavigateToFavoritesBox);
        // 在启动主窗口之前启动登录窗口
        OpenLoginWindow();
    }

    private void OpenLoginWindow()
    {
        _dialogService.ShowDialog("LoginView", result =>
        {
            if (result.Result != ButtonResult.OK)
            {
                Environment.Exit(0);
            }
            else
            {
                var su = result.Parameters.GetValue<SysUserModel>("user");
            }
        });
    }

    /// <summary>
    /// 点击消息图标触发的导航
    /// </summary>
    /// <param name="obj"></param>
    private void NavigateToMessageBox(object obj)
    {
        _regionManager.RequestNavigate("MessageRegion", "MessageBoxView");
        _regionManager.RequestNavigate("ContentRegion", "ContentBoxView");
    }
    /// <summary>
    /// 点击联系人触发的导航
    /// </summary>
    /// <param name="obj"></param>
    private void NavigateToContactsBox(object obj)
    {
        _regionManager.RequestNavigate("MessageRegion", "MessageBoxView");
        _regionManager.RequestNavigate("ContentRegion", "ContentBoxView");
    }
    /// <summary>
    /// 点击收藏触发的导航
    /// </summary>
    /// <param name="obj"></param>
    private void NavigateToFavoritesBox(object obj)
    {
        _regionManager.RequestNavigate("MessageRegion", "MessageBoxView");
        _regionManager.RequestNavigate("ContentRegion", "ContentBoxView");
    }
}