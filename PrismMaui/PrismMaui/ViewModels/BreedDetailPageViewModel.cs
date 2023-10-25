using PrismMaui.Events;
using PrismMaui.Models;
using PrismMaui.Services.Interfaces;
using PrismMaui.Views;
using System.Collections.ObjectModel;

namespace PrismMaui.ViewModels
{
    public class BreedDetailPageViewModel : BaseViewModel
    {
        private INavigationService navigationService;
        private IEventAggregator eventAggregator;
        private ICatService catService;

        public BreedDetailPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator, ICatService catService)
        {
            this.navigationService = navigationService;
            this.eventAggregator = eventAggregator;
            this.catService = catService;
            Title = "Breed detail";
            GoBackCommand = new DelegateCommand(OnGoBackCommandExecuted);
            TabbedPageCommand = new DelegateCommand(OnTabbedPageCommandExecuted);
            ItemTappedCommand = new DelegateCommand<CatImage>(OnItemTappedCommandExecuted);
        }

        public DelegateCommand GoBackCommand { get; }
        public DelegateCommand TabbedPageCommand { get; }
        public DelegateCommand<CatImage> ItemTappedCommand { get; }

        private CatBreed catBreed;
        public CatBreed CatBreed
        {
            get => catBreed;
            set => SetProperty(ref catBreed, value);
        }

        private ObservableCollection<CatImage> catImages = new ObservableCollection<CatImage>();
        public ObservableCollection<CatImage> CatImages
        {
            get => catImages;
            set => SetProperty(ref catImages, value);
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            CatBreed = parameters.GetValue<CatBreed>("catBreed");
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                var result = await catService.SearchCatImagesById(CatBreed.Id);
                CatImages = new ObservableCollection<CatImage>(result);
            }
            catch (Exception ex)
            {
                // Todo
            }
        }

        private async void OnGoBackCommandExecuted()
        {
            await navigationService.GoBackAsync();
        }

        private async void OnTabbedPageCommandExecuted()
        {
            var route = $"/CatTabbedPage?{KnownNavigationParameters.CreateTab}=NavigationPage|{nameof(MainPage)}&{KnownNavigationParameters.CreateTab}={nameof(BreedDetailPage)}";
            await navigationService.NavigateAsync(route);
        }

        private void OnItemTappedCommandExecuted(CatImage catImage)
        {
            catImage.IsSelected = !catImage.IsSelected;
            eventAggregator.GetEvent<BreedImageSelectedEvent>().Publish(catImage.Url);
        }
    }
}
