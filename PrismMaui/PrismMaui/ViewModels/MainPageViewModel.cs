using PrismMaui.Models;
using PrismMaui.Services.Interfaces;
using PrismMaui.Views;
using System.Collections.ObjectModel;

namespace PrismMaui.ViewModels;

public class MainPageViewModel : BaseViewModel
{
    private INavigationService navigationService;
    private ICatService catService;

    public MainPageViewModel(INavigationService navigationService, ICatService catService)
    {
        this.navigationService = navigationService;
        this.catService = catService;
        Title = "Main Page";
        ItemTappedCommand = new DelegateCommand<CatBreed>(OnItemTappedCommandExecuted);
    }

    public DelegateCommand<CatBreed> ItemTappedCommand { get; }

    private ObservableCollection<CatBreed> catBreeds = new ObservableCollection<CatBreed>();
    public ObservableCollection<CatBreed> CatBreeds
    {
        get => catBreeds;
        set => SetProperty(ref catBreeds, value);
    }

    public override void Initialize(INavigationParameters parameters)
    {
        base.Initialize(parameters);
        Task.Run(LoadData);
    }

    private async Task LoadData()
    {
        try
        {
            var result = await catService.SearchAllBreeds();
            CatBreeds = new ObservableCollection<CatBreed>(result);
        }
        catch (Exception ex)
        {
            // Todo
        }
    }

    private async void OnItemTappedCommandExecuted(CatBreed catBreed)
    {
        var navigationParams = new NavigationParameters
        {
            { "catBreed", catBreed }
        };
        await navigationService.NavigateAsync(nameof(BreedDetailPage), navigationParams);
    }
}
