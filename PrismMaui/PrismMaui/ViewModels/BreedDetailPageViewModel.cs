using PrismMaui.Models;
using PrismMaui.Services.Interfaces;
using System.Collections.ObjectModel;

namespace PrismMaui.ViewModels
{
    public class BreedDetailPageViewModel : BaseViewModel
    {
        private INavigationService navigationService;
        private ICatService catService;

        public BreedDetailPageViewModel(INavigationService navigationService, ICatService catService)
        {
            this.navigationService = navigationService;
            this.catService = catService;
            Title = "Breed detail";
            GoBackCommand = new DelegateCommand(OnGoBackCommandExecuted);
        }

        public DelegateCommand GoBackCommand { get; }

        private CatBreed catBreed;
        public CatBreed CatBreed
        {
            get => catBreed;
            set => SetProperty(ref catBreed, value);
        }

        private CatImage catImage;
        public CatImage CatImage
        {
            get => catImage;
            set => SetProperty(ref catImage, value);
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
                var result = await catService.SearchCatImageById(CatBreed.Id);
                CatImage = await catService.SearchCatImageById(CatBreed.Id);
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
    }
}
