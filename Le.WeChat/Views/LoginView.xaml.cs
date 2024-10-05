using System.Windows;
using System.Windows.Controls;

namespace LeWeChat.Views;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        InitializeComponent();
    }

    private void Button_Close_Click(object sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }

}