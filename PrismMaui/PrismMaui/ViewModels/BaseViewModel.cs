using Prism.Ioc;

namespace PrismMaui.ViewModels
{
    public class BaseViewModel : BindableBase, IInitialize, IPageLifecycleAware, INavigationAware
    {
        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        public virtual void OnAppearing()
        {
        }

        public virtual void OnDisappearing()
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }
    }
}
