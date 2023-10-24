using PrismMaui.Apis;
using PrismMaui.Apis.Interfaces;
using PrismMaui.Services;
using PrismMaui.Services.Interfaces;
using PrismMaui.ViewModels;
using PrismMaui.Views;

namespace PrismMaui;

internal static class PrismStartup
{
    public static void Configure(PrismAppBuilder builder)
    {
        builder
            .RegisterTypes(RegisterTypes)
            .OnAppStart("NavigationPage/MainPage");
    }

    private static void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // Register Services
        containerRegistry
            .Register(typeof(IApiService<>), typeof(ApiService<>))
            .Register<IMapperService, MapperService>()
            .Register<ICatService, CatService>();

        // Register Views for navigation
        containerRegistry
            .RegisterForNavigation<MainPage>()
            .RegisterForNavigation<BreedDetailPage>();

        // Register ViewModelLocator for better performance (does not need to use reflection)
        // Note that it still works even if we do not manually register
        ViewModelLocationProvider.Register<MainPage, MainPageViewModel>();
        ViewModelLocationProvider.Register<BreedDetailPage, BreedDetailPageViewModel>();
    }
}
