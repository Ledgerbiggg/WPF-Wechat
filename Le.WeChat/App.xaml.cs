using System.Configuration;
using System.Data;
using System.Windows;
using Le.WeChat.Service.IService;
using Le.WeChat.Service.Service;
using LeWeChat.Views;
using Prism.Ioc;
using Prism.Unity;

namespace LeWeChat;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // 注册服务
        containerRegistry.Register<IMessageService, MessageService>();
    }

    protected override Window CreateShell()
    {
        return Container.Resolve<MainView>();
    }
}