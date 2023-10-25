namespace PrismMaui.ViewModels
{
    public class CatTabbedPageViewModel : BaseViewModel
    {
        private INavigationService navigationService;

        public CatTabbedPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            Title = "Cat Tabbed Page";
        }
    }
}
