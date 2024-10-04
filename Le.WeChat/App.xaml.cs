using System.Configuration;
using System.Data;
using System.Windows;
using Le.WeChat.Service.IService;
using Le.WeChat.Service.Service;
using LeWeChat.Views;
using LeWeChat.Views.Pages;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;

namespace LeWeChat;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    /// <summary>
    /// 注册一些东西
    /// </summary>
    /// <param name="containerRegistry"></param>
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // 注册服务
        containerRegistry.Register<IMessageService, MessageService>();
        // 注册导航
        containerRegistry.RegisterForNavigation<MessageBoxView>();
        containerRegistry.RegisterForNavigation<ContentBoxView>();
    }

    /// <summary>
    /// 创建一个主窗口
    /// </summary>
    /// <returns></returns>
    protected override Window CreateShell()
    {
        // 创建一个住窗口
        return Container.Resolve<MainView>();
    }

    /// <summary>
    /// 定义一个最开始的路由
    /// </summary>
    /// <param name="shell"></param>
    protected override void InitializeShell(Window shell)
    {
        base.InitializeShell(shell);

        // 打开初始的消息页面
        Container.Resolve<IRegionManager>().RequestNavigate("MessageRegion", "MessageBoxView");
        Container.Resolve<IRegionManager>().RequestNavigate("ContentRegion", "ContentBoxView");
    }
}