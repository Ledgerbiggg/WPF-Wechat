using System.Runtime.InteropServices;
using System.Windows;

namespace LeWeChat.Views;

public partial class MainView : Window
{
    // Windows API常量
    private const int GWL_EXSTYLE = -20;
    private const int WS_EX_TOPMOST = 0x00000008;
    private const int WS_EX_NOACTIVATE = 0x08000000;

    // 导入Windows API
    [DllImport("user32.dll")]
    private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
    private static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
    private const uint SWP_NOSIZE = 0x0001;
    private const uint SWP_NOMOVE = 0x0002;
    public MainView()
    {
        InitializeComponent();
    }

    private void ButtonPin_Click(object sender, RoutedEventArgs e)
    {
        // 获取当前窗口句柄
        IntPtr hWnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;

        // 获取当前窗口样式
        int exStyle = GetWindowLong(hWnd, GWL_EXSTYLE);

        // 如果窗口不是最上层窗口，则将其设置为最上层
        if ((exStyle & WS_EX_TOPMOST) == 0)
        {
            SetWindowLong(hWnd, GWL_EXSTYLE, exStyle | WS_EX_TOPMOST);
            SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
        }
        else // 如果已经是最上层窗口，则取消最上层
        {
            SetWindowLong(hWnd, GWL_EXSTYLE, exStyle & ~WS_EX_TOPMOST);
            SetWindowPos(hWnd, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
        }
    }

    private void ButtonMin_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void ButtonMax_Click(object sender, RoutedEventArgs e)
    {
        if (this.WindowState == WindowState.Maximized)
            this.WindowState = WindowState.Normal;
        else
            this.WindowState = WindowState.Maximized;
    }

    private void Button_Close_Click(object sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }
}