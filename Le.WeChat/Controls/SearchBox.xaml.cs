using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace LeWeChat.Controls;

public partial class SearchBox : UserControl
{
    public SearchBox()
    {
        InitializeComponent();
    }

    public ObservableCollection<string> SearchList
    {
        get { return (ObservableCollection<string>)GetValue(SearchListProperty); }
        set { SetValue(SearchListProperty, value); }
    }

    public static readonly DependencyProperty SearchListProperty =
        DependencyProperty.Register("SearchList", typeof(ObservableCollection<string>), typeof(SearchBox),
            new PropertyMetadata(new ObservableCollection<string>()));
}