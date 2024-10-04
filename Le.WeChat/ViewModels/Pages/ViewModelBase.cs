using Prism.Mvvm;

namespace LeWeChat.ViewModels.Pages;

public abstract class ViewModelBase : BindableBase
{
    public virtual void NavigateToSelf(){}
}