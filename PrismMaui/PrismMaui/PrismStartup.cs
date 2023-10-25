using Prism;
using Prism.Ioc;
using Prism.Mvvm;
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
            .RegisterForNavigation<CatTabbedPage, CatTabbedPageViewModel>()
            .RegisterForNavigation<MainPage, MainPageViewModel>()
            .RegisterForNavigation<BreedDetailPage, BreedDetailPageViewModel>();
    }
}
