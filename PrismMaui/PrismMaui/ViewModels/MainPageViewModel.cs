using Prism.Events;
using PrismMaui.Events;
using PrismMaui.Models;
using PrismMaui.Services.Interfaces;
using PrismMaui.Views;
using System.Collections.ObjectModel;

namespace PrismMaui.ViewModels;

public class MainPageViewModel : BaseViewModel
{
    private INavigationService navigationService;
    private IEventAggregator eventAggregator;
    private ICatService catService;

    public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator, ICatService catService)
    {
        this.navigationService = navigationService;
        this.eventAggregator = eventAggregator;
        this.catService = catService;
        Title = "Main Page";
        ItemTappedCommand = new DelegateCommand<CatBreed>(OnItemTappedCommandExecuted);
        eventAggregator.GetEvent<BreedImageSelectedEvent>().Subscribe(OnBreedImageSelectedChanged);
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

    private int maxTrigger = 10;
    private void OnBreedImageSelectedChanged(string obj)
    {
        System.Diagnostics.Debug.WriteLine($"Breed url: {obj}");
        maxTrigger--;
        if (maxTrigger <= 0) eventAggregator.GetEvent<BreedImageSelectedEvent>().Unsubscribe(OnBreedImageSelectedChanged);
    }
}
